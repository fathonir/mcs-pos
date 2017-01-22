using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;

namespace MCS_POS.Model
{
    public class KartuStok
    {
        public int ID_Kartu_Stok { get; set; }
        public int ID_Departemen { get; set; }
        public int ID_Item { get; set; }

        public string Tipe { get; set; }
        public string Keterangan { get; set; }

        public string Kode_Transaksi { get; set; }
        public DateTime Waktu_Transaksi { get; set; }

        public int Masuk { get; set; }
        public int Keluar { get; set; }
        public int Saldo { get; set; }

        // Referensi
        public int ID_Saldo_Awal { get; set; }
        public int ID_Pembelian { get; set; }
        public int ID_Penjualan { get; set; }

        public static List<KartuStok> GetList(IDbConnection dbConnection, Departemen departemen, Item item, string bulanPeriode, int tahunPeriode)
        {
            // Prepare filter
            var awal = Convert.ToDateTime("01 " + bulanPeriode + " " + tahunPeriode);
            var akhir = awal.AddMonths(1).AddSeconds(-1d);

            var sql = @"
                SELECT * FROM kartu_stok 
                WHERE 
                    id_departemen = @id_departemen AND
                    id_item = @id_item AND 
                    waktu_transaksi BETWEEN @awal AND @akhir 
                ORDER BY waktu_transaksi ASC";

            return dbConnection.Query<KartuStok>(sql, new { 
                id_departemen = departemen.ID_Departemen,
                id_item = item.ID_Item, 
                awal = awal, 
                akhir = akhir 
            }).ToList();
        }

        /// <summary>
        /// Proses bulanan untuk me-refresh kembali perhitungan kartu stok yang missing pada saat proses transaksi.
        /// Proses ini juga digunakan untuk memindah jumlah saldo pada periode berikutnya.
        /// </summary>
        public static void ProsesBulanan(IDbTransaction t, Departemen dept, string bulanPeriode, int tahunPeriode, DateTime periodeAwal, bool isUpdateStok = false)
        {
            var tanggalSatu = Convert.ToDateTime("01 " + bulanPeriode + " " + tahunPeriode);
            var akhirBulan = tanggalSatu.AddMonths(1).AddSeconds(-1d);

            string sql;
            int affected = 0;

            // Proses saldo awal jika periode yg diproses = periode awal
            if (tanggalSatu == periodeAwal)
            {
                // Clear row kartu stok
                sql = "DELETE FROM kartu_stok WHERE id_departemen = @id_departemen AND (waktu_transaksi BETWEEN @awal AND @akhir)";
                affected = t.Connection.Execute(sql, new
                {
                    id_departemen = dept.ID_Departemen,
                    awal = tanggalSatu,
                    akhir = akhirBulan
                }, t);

                // insert saldo awal semua item ke kartu stok
                sql = @"insert into kartu_stok (id_departemen, id_item, tipe, kode_transaksi, waktu_transaksi, masuk, keluar, saldo, id_saldo_awal)
                        select sa.id_departemen, sa.id_item, 'SA', NULL, tanggal_saldo_awal, 0, 0, sa.jumlah * si.konversi_jumlah, id_saldo_awal
                        from saldo_awal sa
                        join satuan_item si on si.id_item = sa.id_item and si.id_satuan = sa.id_satuan
                        where tanggal_saldo_awal = @tanggal_saldo_awal and sa.id_departemen = @id_departemen";
                affected += t.Connection.Execute(sql, new { tanggal_saldo_awal = periodeAwal, id_departemen = dept.ID_Departemen }, t);

                // Proses Saldo awal kosongan, untuk item yg tidak punya transaksi saldo awal
                sql = @"insert into kartu_stok (id_departemen, id_item, tipe, kode_transaksi, waktu_transaksi, masuk, keluar, saldo)
                        select @id_departemen, id_item, 'SA', NULL, @awal, 0, 0, 0 from item
                        where id_item not in (select id_item from kartu_stok where id_departemen = @id_departemen and tipe = 'SA' and waktu_transaksi between @awal and @akhir)";
                affected += t.Connection.Execute(sql, new { id_departemen = dept.ID_Departemen, awal = tanggalSatu, akhir = akhirBulan }, t);
            }
            else
            {
                // Clear kartu_stok yg bukan saldo awal, karena saldo awal di proses saat proses bulanan
                // periode sebelumnya.
                sql = @"DELETE FROM kartu_stok WHERE id_departemen = @id_departemen AND 
                        waktu_transaksi BETWEEN @awal AND @akhir AND tipe NOT IN ('SA')";
                affected = t.Connection.Execute(sql, new
                {
                    id_departemen = dept.ID_Departemen,
                    awal = tanggalSatu,
                    akhir = akhirBulan
                }, t);
            }

            // ============================
            // Tambahkan Proses Penjualan
            // ============================
            sql = @"
                INSERT INTO kartu_stok (
                    id_departemen, id_item, tipe, kode_transaksi, waktu_transaksi,
                    masuk, keluar, saldo,
                    id_saldo_awal, id_pembelian, id_penjualan)
                SELECT
                    p.id_departemen, pd.id_item, 'JL', p.kode_transaksi, p.waktu_transaksi,
                    (pd.jumlah_refund * si.konversi_jumlah) AS masuk, (pd.jumlah * si.konversi_jumlah) AS keluar, 0 AS saldo,
                    NULL AS id_saldo_awal, NULL AS id_pembelian, p.id_penjualan
                FROM penjualan p
                JOIN penjualan_detail pd ON pd.id_penjualan = p.id_penjualan
                JOIN satuan_item si ON si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                WHERE p.id_departemen = @id_departemen AND p.waktu_transaksi BETWEEN @awal AND @akhir";

            affected += t.Connection.Execute(sql, new { id_departemen = dept.ID_Departemen, awal = tanggalSatu, akhir = akhirBulan }, t);



            // ============================
            // Tambahkan Proses Pembelian
            // ============================
            sql = @"
                INSERT INTO kartu_stok (
                    id_departemen, id_item, tipe, kode_transaksi, waktu_transaksi, 
                    masuk, keluar, saldo, 
                    id_saldo_awal, id_pembelian, id_penjualan)
                SELECT 
                    p.id_departemen, pd.id_item, 'BL', p.kode_transaksi, p.waktu_transaksi,
                    pd.jumlah * si.konversi_jumlah AS masuk, 0 AS keluar, 0 AS saldo, 
                    NULL AS id_saldo_awal, p.id_pembelian, NULL as id_penjualan
                FROM pembelian p
                JOIN pembelian_detail pd ON pd.id_pembelian = p.id_pembelian
                JOIN satuan_item si ON si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                WHERE p.id_departemen = @id_departemen AND p.waktu_transaksi BETWEEN @awal AND @akhir";

            affected += t.Connection.Execute(sql, new { id_departemen = dept.ID_Departemen, awal = tanggalSatu, akhir = akhirBulan }, t);



            // ============================
            // Tambahkan Proses Stok Opname
            // ============================
            sql = @"
                INSERT INTO kartu_stok (id_departemen, id_item, tipe, waktu_transaksi, masuk, keluar, saldo, id_stok_opname)
                SELECT so.id_departemen, so.id_item, 'OP', so.tanggal_opname,
	                opname_masuk AS masuk, opname_keluar AS keluar, 0 AS saldo, id_stok_opname
                FROM stok_opname so
                WHERE so.id_departemen = @id_departemen AND so.tanggal_opname BETWEEN @awal AND @akhir";

            affected += t.Connection.Execute(sql, new { id_departemen = dept.ID_Departemen, awal = tanggalSatu, akhir = akhirBulan }, t);



            // ===============================
            // Tambahkan Proses Transfer Item
            // ===============================
            sql = @"
                INSERT INTO kartu_stok (id_departemen, id_item, tipe, kode_transaksi, waktu_transaksi, masuk, keluar, saldo, id_transfer)
                /* Item Keluar dr departemen yg diproses */
                SELECT t.id_departemen_asal, td.id_item, 'TR', t.kode_transaksi, t.waktu_transaksi, 0 AS masuk, td.jumlah * si.konversi_jumlah AS keluar, 0 as saldo, t.id_transfer
                FROM transfer t
                JOIN transfer_detail td ON td.id_transfer = t.id_transfer
                JOIN satuan_item si ON si.id_item = td.id_item AND si.id_satuan = td.id_satuan
                WHERE t.id_departemen_asal = @id_departemen AND t.waktu_transaksi BETWEEN @awal AND @akhir
                UNION ALL
                /* Item Masuk ke departemen yg diproses */
                SELECT t.id_departemen_tujuan, td.id_item, 'TR', t.kode_transaksi, t.waktu_transaksi, td.jumlah * si.konversi_jumlah AS masuk, 0 AS keluar, 0 as saldo, t.id_transfer
                FROM transfer t
                JOIN transfer_detail td ON td.id_transfer = t.id_transfer
                JOIN satuan_item si ON si.id_item = td.id_item AND si.id_satuan = td.id_satuan
                WHERE t.id_departemen_tujuan = @id_departemen AND t.waktu_transaksi BETWEEN @awal AND @akhir";

            affected += t.Connection.Execute(sql, new { id_departemen = dept.ID_Departemen, awal = tanggalSatu, akhir = akhirBulan }, t);


            // ====================================
            // Clear saldo awal periode berikutnya 
            // ====================================
            sql = @"DELETE FROM kartu_stok WHERE id_departemen = @id_departemen AND 
                    waktu_transaksi = @waktu_transaksi AND tipe = 'SA'";
            t.Connection.Execute(sql, new { id_departemen = dept.ID_Departemen, waktu_transaksi = tanggalSatu.AddMonths(1) }, t);
            
            // Load id_item selama satu periode
            var itemInKartuStok =
                t.Connection.Query("select distinct id_item from kartu_stok where id_departemen = @id_departemen and waktu_transaksi between @awal and @akhir order by 1",
                new
                {
                    id_departemen = dept.ID_Departemen,
                    awal = tanggalSatu,
                    akhir = akhirBulan
                });

            // ================================================
            // Proses menghitung perjalanan stok
            // =================================================

            foreach (var item in itemInKartuStok)
            {
                // Load kartu stok Item selama satu periode
                var kartuStokList =
                    t.Connection.Query<KartuStok>("select id_kartu_stok, id_item, masuk, keluar, saldo from kartu_stok where id_departemen = @id_departemen and id_item = @id_item and waktu_transaksi between @awal and @akhir order by waktu_transaksi asc",
                    new {
                        id_departemen = dept.ID_Departemen,
                        id_item = item.id_item,
                        awal = tanggalSatu,
                        akhir = akhirBulan
                    });

                // Yang diproses hanya item yg mempunyai min 2 transaksi atau lebih (1 transaksi merupakan saldo awal)
                if (kartuStokList.Count() >= 2)
                {
                    sql = "update kartu_stok set saldo = @saldo where id_kartu_stok = @id_kartu_stok";

                    // Assignment
                    KartuStok kartuStokBefore = kartuStokList.ElementAt(0);
                    KartuStok kartuStok = kartuStokList.ElementAt(1);

                    // Proses tiap Item
                    for (int i = 1; i < kartuStokList.Count(); i++)
                    {
                        kartuStokBefore = kartuStokList.ElementAt(i - 1);
                        kartuStok = kartuStokList.ElementAt(i);

                        // Proses Saldo
                        kartuStok.Saldo = kartuStokBefore.Saldo + kartuStok.Masuk - kartuStok.Keluar;

                        // Update Kartu Stok
                        affected += t.Connection.Execute(sql, kartuStok, t);
                    }

                    // Insert Saldo Awal periode berikutnya
                    t.Connection.Execute("insert into kartu_stok (id_departemen, id_item, tipe, waktu_transaksi, saldo) values (@id_departemen, @id_item, 'SA', @waktu_transaksi, @saldo)",
                        new
                        {
                            id_departemen = dept.ID_Departemen,
                            id_item = kartuStok.ID_Item,
                            waktu_transaksi = tanggalSatu.AddMonths(1),
                            saldo = kartuStok.Saldo
                        });
                }

                // Jika hanya 1 transaksi -> Saldo Awal Saja
                // Langsung insert saldo awal periode berikutnya
                else if (kartuStokList.Count() == 1) 
                {
                    // ambil kartu stok terakhir
                    var kartuStok = kartuStokList.ElementAt(0);

                    // Insert Saldo Awal periode berikutnya
                    t.Connection.Execute("insert into kartu_stok (id_departemen, id_item, tipe, waktu_transaksi, saldo) values (@id_departemen, @id_item, 'SA', @waktu_transaksi, @saldo)",
                        new
                        {
                            id_departemen = dept.ID_Departemen,
                            id_item = kartuStok.ID_Item,
                            waktu_transaksi = tanggalSatu.AddMonths(1),
                            saldo = kartuStok.Saldo
                        });
                }


                // Update stok item sesuai dengan jumlah saldo terakhir transaksi
                // Hanya dilakukan ketika memproses bulanan pada periode sedang aktif
                if (isUpdateStok && tanggalSatu.Year == DateTime.Today.Year && tanggalSatu.Month == DateTime.Today.Month)
                {
                    sql = "UPDATE stok_item SET stok = @stok WHERE id_departemen = @id_departemen AND id_item = @id_item";
                    t.Connection.Execute(sql, new { 
                        stok = kartuStokList.Last().Saldo,
                        id_departemen = dept.ID_Departemen,
                        id_item = item.id_item
                    }, t);
                }
            }
        }

        /// <summary>
        /// Update saldo setelah stok opname. Dilakukan agar perhitungan saldo pada satu periode tepat.
        /// Memproses hitungan saldo setelah stok opname
        /// </summary>
        public static void ProsesStokOpname(IDbTransaction t, StokOpname so)
        {
            Console.WriteLine("id_item : " + so.ID_Item + "   Fisik : " + so.Fisik);
            // Ambil kartu stok setelah opname
        }

        /// <summary>
        /// Tambah transaki kartu stok ketika penjualan. Kode: JL
        /// </summary>
        public static bool AddPenjualan(IDbTransaction t, Penjualan p)
        {
            var sql = @"
                INSERT INTO kartu_stok (
                    id_departemen, id_item, tipe, kode_transaksi, waktu_transaksi, 
                    masuk, keluar, saldo, 
                    id_saldo_awal, id_pembelian, id_penjualan)
                SELECT 
                    p.id_departemen, pd.id_item, 'JL', p.kode_transaksi, p.waktu_transaksi, 
                    (pd.jumlah_refund * si.konversi_jumlah) AS masuk, (pd.jumlah * si.konversi_jumlah) AS keluar, stok.stok AS saldo, 
                    NULL AS id_saldo_awal, NULL AS id_pembelian, p.id_penjualan
                FROM penjualan p
                JOIN penjualan_detail pd ON pd.id_penjualan = p.id_penjualan
                JOIN satuan_item si ON si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                JOIN stok_item stok ON stok.id_departemen = p.id_departemen AND stok.id_item = pd.id_item
                WHERE p.id_departemen = @id_departemen AND p.id_penjualan = @id_penjualan";

            var affected = t.Connection.Execute(sql, p, t);

            return (affected > 0);
        }

        /// <summary>
        /// Update stok item pada kartu stok ketika refund
        /// </summary>
        public static bool UpdatePenjualanRefund(IDbTransaction t, Penjualan p)
        {
            var sql = @" 
                UPDATE kartu_stok k
                  JOIN item i ON i.id_item = k.id_item
                  JOIN stok_item stok ON stok.id_departemen = k.id_departemen AND stok.id_item = k.id_item
                  JOIN penjualan_detail pd ON pd.id_penjualan = k.id_penjualan AND pd.id_item = k.id_item
                  JOIN satuan_item si ON si.id_item = k.id_item AND si.id_satuan = pd.id_satuan
                SET
                  k.saldo = stok.stok,
                  k.keluar = (pd.jumlah - pd.jumlah_refund) * si.konversi_jumlah
                WHERE k.id_departemen = @id_departemen AND k.id_penjualan = @id_penjualan";
            
            var affected = t.Connection.Execute(sql, p, t);

            return (affected > 0);
        }

        /// <summary>
        /// Tambah transaksi kartu stok ketika pembelian. Kode: BL
        /// </summary>
        public static bool AddPembelian(IDbTransaction t, Pembelian p)
        {
            var sql = @"
                INSERT INTO kartu_stok (
                    id_departemen, id_item, tipe, kode_transaksi, waktu_transaksi, 
                    masuk, keluar, saldo, 
                    id_saldo_awal, id_pembelian, id_penjualan)
                SELECT 
                    p.id_departemen, pd.id_item, 'BL', p.kode_transaksi, p.waktu_transaksi,
                    pd.jumlah * si.konversi_jumlah AS masuk, 0 AS keluar, stok.stok AS saldo, 
                    NULL AS id_saldo_awal, p.id_pembelian, NULL as id_penjualan
                FROM pembelian p
                JOIN pembelian_detail pd ON pd.id_pembelian = p.id_pembelian
                JOIN satuan_item si ON si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                JOIN stok_item stok ON stok.id_departemen = p.id_departemen AND stok.id_item = pd.id_item
                WHERE p.id_departemen = @id_departemen AND p.id_pembelian = @id_pembelian";

            var affected = t.Connection.Execute(sql, p, t);

            return (affected > 0);
        }

        public static bool UpdatePembelian(IDbTransaction transaction, Pembelian pembelian)
        {
            // Cara update
            // --> Clear kartu stok
            // --> Insert ulang

            var sql = @"DELETE FROM kartu_stok WHERE id_pembelian = @id_pembelian";
            var affected = transaction.Connection.Execute(sql, pembelian, transaction);

            var addResult = KartuStok.AddPembelian(transaction, pembelian);

            return (affected > 0) && addResult;
        }

        /// <summary>
        /// Tambah kartu stok untuk stok opname. Proses ini juga mengupdate semua kartu stok setelah tanggal stok opname
        /// </summary>
        public static bool AddStokOpname(IDbTransaction t, StokOpname so)
        {
            // Notes :
            //   Saldo dr Stok Opname = Saldo Awal periode + Selisih perubahan stok opname

            // SQL tambah kartu stok utk stok opname
            var sql = @"
                INSERT INTO kartu_stok (id_departemen, id_item, tipe, waktu_transaksi, masuk, keluar, saldo, id_stok_opname)
                SELECT so.id_departemen, so.id_item, 'OP', so.tanggal_opname,
	                opname_masuk AS masuk, opname_keluar AS keluar, @awal + @selisih AS saldo, id_stok_opname
                FROM stok_opname so
                WHERE so.id_departemen = @id_departemen AND so.id_stok_opname = @id_stok_opname";
            
            var affected = t.Connection.Execute(sql, so, t);

            // ================================================
            // Mengupdate perjalanan saldo setelah stok opname
            // ================================================

            // Persiapan rentang periode
            var awal = so.Tanggal_Opname;
            var akhir = new DateTime(awal.Year, awal.Month + 1, 1); // tanggal 1 bulan berikutnya

            // Ambil data kartu stok setelah stok opname dalam satu periode stok opname
            sql = @"
                SELECT * FROM kartu_stok 
                WHERE 
                    id_departemen = @id_departemen AND id_item = @id_item AND
                    waktu_transaksi > @awal AND waktu_transaksi < @akhir
                ORDER BY waktu_transaksi ASC";

            var kartuStokList = t.Connection.Query<KartuStok>(sql, new { 
                id_departemen = so.ID_Departemen,
                id_item = so.ID_Item,
                awal = so.Tanggal_Opname,
                akhir = new DateTime(awal.Year, awal.Month + 1, 1)
            });

            // ambil saldo terakhir
            var saldoTerakhir = so.Awal + so.Selisih;

            // Pastikan ada kartu stok utk diproses
            if (kartuStokList.Count() > 0)
            {
                // Utk kartu stok pertama proses dari stok opname
                var kartuStokBefore = kartuStokList.ElementAt(0);
                kartuStokBefore.Saldo = (so.Awal + so.Selisih) + kartuStokBefore.Masuk - kartuStokBefore.Keluar;

                // SQL Update
                sql = @"UPDATE kartu_stok SET saldo = @saldo WHERE id_kartu_stok = @id_kartu_stok";
                affected += t.Connection.Execute(sql, kartuStokBefore, t);

                // sesuaikan saldo terakhir
                saldoTerakhir = kartuStokBefore.Saldo;

                // pastikan lebih dari 1
                if (kartuStokList.Count() > 1)
                {
                    // utk kartu stok ke dua dst, proses dari kartu stok sebelumnya
                    for (int i = 1; i < kartuStokList.Count(); i++)
                    {
                        // proses saldo
                        var kartuStok = kartuStokList.ElementAt(i);
                        kartuStok.Saldo = kartuStokBefore.Saldo + kartuStok.Masuk - kartuStok.Keluar;

                        saldoTerakhir = kartuStok.Saldo;

                        // update kartu stok
                        affected += t.Connection.Execute(sql, kartuStok, t);

                        // pindah ref kartuStokBefore
                        kartuStokBefore = kartuStok;
                    }
                }
            }

            return (affected > 0);
        }

        public static bool UpdateStokOpname(IDbTransaction t, StokOpname so)
        {
            var sql = @"
                UPDATE kartu_stok k
	                JOIN stok_opname so ON so.id_stok_opname = k.id_stok_opname
	                JOIN stok_item stok ON stok.id_departemen = so.id_departemen AND stok.id_item = k.id_item
                SET
	                masuk = so.opname_masuk,
	                keluar = so.opname_keluar,
                    saldo = stok.stok
                WHERE so.id_departemen = @id_departemen AND so.id_stok_opname = @id_stok_opname";

            var affected = t.Connection.Execute(sql, so, t);

            return (affected > 0);
        }

        /// <summary>
        /// Menambahkan informasi transfer item pada kartu stok. Kode: TR
        /// </summary>
        public static bool AddTransfer(IDbTransaction t, Transfer transfer)
        {
            var sql = @"
                INSERT INTO kartu_stok (id_departemen, id_item, tipe, kode_transaksi, waktu_transaksi, masuk, keluar, id_transfer) 
                /* Item Keluar */
                SELECT t.id_departemen_asal, td.id_item, 'TR', t.kode_transaksi, t.waktu_transaksi, 0 AS masuk, td.jumlah * si.konversi_jumlah AS keluar, t.id_transfer
                FROM transfer t
                JOIN transfer_detail td ON td.id_transfer = t.id_transfer
                JOIN satuan_item si ON si.id_item = td.id_item AND si.id_satuan = td.id_satuan
                WHERE t.id_transfer = @id_transfer
                UNION ALL
                /* Item Masuk */
                SELECT t.id_departemen_tujuan, td.id_item, 'TR', t.kode_transaksi, t.waktu_transaksi, td.jumlah * si.konversi_jumlah AS masuk, 0 AS keluar, t.id_transfer
                FROM transfer t
                JOIN transfer_detail td ON td.id_transfer = t.id_transfer
                JOIN satuan_item si ON si.id_item = td.id_item AND si.id_satuan = td.id_satuan
                WHERE t.id_transfer = @id_transfer";

            var affected = t.Connection.Execute(sql, transfer, t);

            return (affected > 0);
        }

        /// <summary>
        /// Mengupdate informasi kartu stok setelah ada perubahan transaksi transfer
        /// </summary>
        public static bool UpdateTransfer(IDbTransaction t, Transfer transfer)
        {
            // Cara update
            // --> Clear kartu stok
            // --> Insert ulang

            var sql = @"DELETE FROM kartu_stok WHERE id_transfer = @id_transfer";
            var affected = t.Connection.Execute(sql, transfer, t);

            var addResult = KartuStok.AddTransfer(t, transfer);

            return (affected > 0) && addResult;
        }

        /// <summary>
        /// Tambah proses stok untuk konsinyasi baru. Kode : KIN
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="konsinyasi"></param>
        public static bool AddKonsinyasi(IDbTransaction transaction, Konsinyasi konsinyasi)
        {
            var sql = @"
                INSERT INTO kartu_stok (
                    id_departemen, id_item, tipe, kode_transaksi, waktu_transaksi, 
                    masuk, keluar, saldo, id_konsinyasi)
                SELECT 
                    k.id_departemen, kd.id_item, 'KIN', k.kode_transaksi, k.waktu_transaksi,
                    kd.jumlah * si.konversi_jumlah AS masuk, 0 AS keluar, stok.stok AS saldo, 
                    k.id_konsinyasi
                FROM konsinyasi k
                JOIN konsinyasi_detail kd ON kd.id_konsinyasi = k.id_konsinyasi
                JOIN satuan_item si ON si.id_item = kd.id_item AND si.id_satuan = kd.id_satuan
                JOIN stok_item stok ON stok.id_departemen = k.id_departemen AND stok.id_item = kd.id_item
                WHERE k.id_departemen = @id_departemen AND k.id_konsinyasi = @id_konsinyasi";

            var affected = transaction.Connection.Execute(sql, konsinyasi, transaction);

            return (affected > 0);
        }

        public static bool UpdateKonsinyasi(IDbTransaction transaction, Konsinyasi konsinyasi)
        {
            // Cara update
            // --> Clear kartu stok
            // --> Insert ulang

            var sql = @"DELETE FROM kartu_stok WHERE id_konsinyasi = @id_konsinyasi";
            var affected = transaction.Connection.Execute(sql, konsinyasi, transaction);

            var addResult = KartuStok.AddKonsinyasi(transaction, konsinyasi);

            return (affected > 0) && addResult;
        }

        

        /// <summary>
        /// Tambah proses stok untuk konsinyasi retur. Kode : RKI
        /// </summary>
        public static bool AddKonsinyasiRetur(IDbTransaction transaction, KonsinyasiRetur konsinyasiRetur)
        {
            var sql = @"
                INSERT INTO kartu_stok (
                    id_departemen, id_item, tipe, kode_transaksi, waktu_transaksi, 
                    masuk, keluar, saldo, id_konsinyasi_retur)
                SELECT 
                    k.id_departemen, kd.id_item, 'RKI', k.kode_transaksi, k.waktu_transaksi,
                    0 AS masuk, kd.jumlah * si.konversi_jumlah AS keluar, stok.stok AS saldo, 
                    k.id_konsinyasi_retur
                FROM konsinyasi_retur k
                JOIN konsinyasi_retur_detail kd ON kd.id_konsinyasi_retur = k.id_konsinyasi_retur
                JOIN satuan_item si ON si.id_item = kd.id_item AND si.id_satuan = kd.id_satuan
                JOIN stok_item stok ON stok.id_departemen = k.id_departemen AND stok.id_item = kd.id_item
                WHERE k.id_departemen = @id_departemen AND k.id_konsinyasi_retur = @id_konsinyasi_retur";

            var affected = transaction.Connection.Execute(sql, konsinyasiRetur, transaction);

            return (affected > 0);
        }

        public static bool UpdateKonsinyasiRetur(IDbTransaction transaction, KonsinyasiRetur konsinyasiRetur)
        {
            // Cara update
            // --> Clear kartu stok
            // --> Insert ulang

            var sql = @"DELETE FROM kartu_stok WHERE id_konsinyasi_retur = @id_konsinyasi_retur";
            var affected = transaction.Connection.Execute(sql, konsinyasiRetur, transaction);

            var addResult = KartuStok.AddKonsinyasiRetur(transaction, konsinyasiRetur);

            return (affected > 0) && addResult;
        }
    }
}
