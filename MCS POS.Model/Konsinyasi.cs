using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data;

namespace MCS_POS.Model
{
    public class Konsinyasi
    {
        public int ID_Konsinyasi { get; set; }
        public int ID_Departemen { get; set; }
        public int ID_User { get; set; }
        public int ID_Supplier { get; set; }

        public string Kode_Transaksi { get; set; }
        public DateTime Waktu_Transaksi { get; set; }
        public int Biaya_Lain { get; set; }
        public int Total_Biaya { get; set; }
        public int Total_Biaya_Akhir { get; set; }
        public int Jumlah_Item { get; set; }

        public DateTime Jatuh_Tempo { get; set; }
        public string No_Informasi { get; set; }
        public string Keterangan { get; set; }

        // reference object
        public Model.Departemen Departemen { get; set; }
        public Model.User User { get; set; }
        public Model.Supplier Supplier { get; set; }
        public List<Model.KonsinyasiDetail> KonsinyasiDetails { get; set; }

        // Row Info
        public Guid GUID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public static string GenerateKodeTransaksi(System.Data.IDbConnection dbConnection, Model.Departemen departemen, List<Config> configs)
        {
            // mendapatkan format, default = [COUNTER]/KIN/[DEPARTEMEN]/[BLN][THN]
            var formatKode = configs.First(s => s.Nama == Model.Config.FORMAT_KODE_KONSINYASI).Nilai;

            // digit counter, default = 4
            var digitCounter = int.Parse(configs.First(s => s.Nama == Model.Config.DIGIT_COUNTER_KONSINYASI).Nilai);

            // reset perulangan counter, default = BULAN
            var resetCounter = configs.First(s => s.Nama == Model.Config.RESET_COUNTER_KONSINYASI).Nilai;

            // mendapatkan jumlah transaksi dalam periode reset
            var transactionCount = 0;


            if (resetCounter == "TAHUN")
            {
                var sql = @"
                    SELECT Count(*) AS count FROM konsinyasi
                    WHERE id_departemen = @id_departemen AND Year(waktu_transaksi) = @tahun";

                transactionCount = dbConnection.ExecuteScalar<int>(sql, new
                {
                    id_departemen = departemen.ID_Departemen,
                    tahun = DateTime.Now.Year
                });
            }

            if (resetCounter == "BULAN")
            {
                var sql = @"
                    SELECT Count(*) AS count FROM konsinyasi
                    WHERE id_departemen = @id_departemen AND Year(waktu_transaksi) = @tahun AND Month(waktu_transaksi) = @bulan";

                transactionCount = dbConnection.ExecuteScalar<int>(sql, new
                {
                    id_departemen = departemen.ID_Departemen,
                    tahun = DateTime.Now.Year,
                    bulan = DateTime.Now.Month
                });
            }

            if (resetCounter == "HARI")
            {
                var sql = @"
                    SELECT Count(*) AS count FROM konsinyasi
                    WHERE id_departemen = @id_departemen AND Year(waktu_transaksi) = @tahun AND Month(waktu_transaksi) = @bulan AND Day(waktu_transaksi) = @tanggal";

                transactionCount = dbConnection.ExecuteScalar<int>(sql, new
                {
                    id_departemen = departemen.ID_Departemen,
                    tahun = DateTime.Now.Year,
                    bulan = DateTime.Now.Month,
                    tanggal = DateTime.Now.Day
                });
            }

            // jika belum ada transaksi
            if (transactionCount == 0)
            {
                // reset sequence
                dbConnection.Execute("UPDATE sequence SET next_value = 1 WHERE sequence_name = 'konsinyasi'");
            }

            string resultKodeTransaksi = "";

            // Generate dan Test kode
            do
            {
                // ambil sequence
                int next_value = dbConnection.ExecuteScalar<int>("SELECT next_value FROM sequence WHERE sequence_name = 'konsinyasi'");

                // increment sequence : di pindah ketika simpan Transaksi Baru
                dbConnection.Execute("UPDATE sequence SET next_value = next_value + increment WHERE sequence_name = 'konsinyasi'");

                // ambil kode departemen
                string kode_departemen = dbConnection.ExecuteScalar<string>("SELECT kode_departemen FROM departemen WHERE id_departemen = " + departemen.ID_Departemen);

                // kembalikan hasil sesuai format kode
                resultKodeTransaksi = formatKode
                    .Replace("[COUNTER]", next_value.ToString().PadLeft(digitCounter, '0'))
                    .Replace("[DEPARTEMEN]", kode_departemen)
                    .Replace("[TGL]", DateTime.Now.ToString("dd"))
                    .Replace("[BLN]", DateTime.Now.ToString("MM"))
                    .Replace("[THN]", DateTime.Now.ToString("yy"));

                // Jika sudah ada, repeat pengambilan sequence
            } while (dbConnection.ExecuteScalar<int>("SELECT count(*) FROM konsinyasi WHERE kode_transaksi = '" + resultKodeTransaksi + "'") > 0);

            // kembalikan hasil
            return resultKodeTransaksi;
        }

        public static bool Add(IDbTransaction transaction, Konsinyasi konsinyasi)
        {
            var sql =
                @"INSERT INTO konsinyasi 
                (id_departemen, id_user, id_supplier, kode_transaksi, waktu_transaksi, biaya_lain, jatuh_tempo, total_biaya, total_biaya_akhir, jumlah_item, guid, created)
                VALUES
                (@id_departemen,@id_user,@id_supplier,@kode_transaksi,@waktu_transaksi,@biaya_lain,@jatuh_tempo,@total_biaya,@total_biaya_akhir,@jumlah_item,@guid,@created)";

            var affected = transaction.Connection.Execute(sql, konsinyasi, transaction);

            // Jika berhasil insert
            if (affected > 0)
            {
                // Ambil ID_Konsinyasi yg berhasil terinsert
                konsinyasi.ID_Konsinyasi = transaction.Connection.ExecuteScalar<int>("SELECT last_insert_id()", null, transaction);

                // Tambahkan detail-detail ke database
                foreach (var kd in konsinyasi.KonsinyasiDetails)
                {
                    // Set FK ID_Konsinyasi
                    kd.ID_Konsinyasi = konsinyasi.ID_Konsinyasi;

                    // SQL insert detail konsinyasi
                    var sql2 =
                        @"INSERT INTO konsinyasi_detail
                        (id_konsinyasi, id_item, id_satuan, jumlah, harga_beli, sub_total)
                        VALUES
                        (@id_konsinyasi,@id_item,@id_satuan,@jumlah,@harga_beli,@sub_total)";

                    // Eksekusi Insert detail konsinyasi
                    affected += transaction.Connection.Execute(sql2, kd, transaction);

                    // SQL Update stok
                    var sql3 =
                        @"UPDATE stok_item s 
                            JOIN satuan_item si ON si.id_item = s.id_item
                        SET s.stok = s.stok + (@jumlah * si.konversi_jumlah)
                        WHERE 
	                        s.id_departemen = @id_departemen AND
                            s.id_item = @id_item AND
                            si.id_satuan = @id_satuan";

                    // Eksekusi update stok
                    affected += transaction.Connection.Execute(sql3, new
                    {
                        jumlah = kd.Jumlah,
                        id_departemen = konsinyasi.ID_Departemen,
                        id_item = kd.ID_Item,
                        id_satuan = kd.ID_Satuan
                    }, transaction);

                }

                // Tambahkan increment konsinyasi
                affected += transaction.Connection.Execute("UPDATE sequence SET next_value = next_value + increment WHERE sequence_name = 'konsinyasi'");
            }

            return (affected > 0);
        }

        public static bool Update(IDbTransaction transaction, Konsinyasi konsinyasi)
        {
            var connection = transaction.Connection;

            var sql =
                @"UPDATE konsinyasi SET
                    waktu_transaksi = @waktu_transaksi,
                    id_supplier = @id_supplier,
                    jatuh_tempo = @jatuh_tempo,
                    jumlah_item = @jumlah_item,
                    total_biaya = @total_biaya,
                    biaya_lain = @biaya_lain,
                    total_biaya_akhir = @total_biaya_akhir,
                    id_user = @id_user,
                    modified = @modified
                WHERE id_konsinyasi = @id_konsinyasi";
            
            var affected = transaction.Connection.Execute(sql, konsinyasi, transaction);

            // =================================================
            // Urutan proses data row : DELETE > UPDATE > INSERT
            // =================================================

            if (affected > 0)
            {
                foreach (var konsinyasiDetail in konsinyasi.KonsinyasiDetails)
                {
                    if (konsinyasiDetail.ForDelete)
                    {
                        // ==============================================================================
                        // Mengurangi stok yg sudah pernah ditambahkan akibat konsinyasi masuk
                        // STOK = STOK - (JUMLAH * KONVERSI)
                        // ==============================================================================
                        sql =
                            @"UPDATE stok_item SET
                                stok = stok - (
                                    SELECT kd.jumlah * si.konversi_jumlah FROM konsinyasi_detail kd
                                    JOIN satuan_item si ON si.id_item = kd.id_item AND si.id_satuan = kd.id_satuan
                                    WHERE kd.id_konsinyasi_detail = @id_konsinyasi_detail)
                            WHERE id_item = @id_item AND id_departemen = @id_departemen";
                        affected += connection.Execute(sql, new {
                            id_konsinyasi_detail = konsinyasiDetail.ID_Konsinyasi_Detail,
                            id_item = konsinyasiDetail.ID_Item,
                            id_departemen = konsinyasi.ID_Departemen
                        }, transaction);

                        // Hapus Item
                        sql = "DELETE FROM konsinyasi_detail WHERE id_konsinyasi_detail = @id_konsinyasi_detail";
                        var deleted = connection.Execute(sql, konsinyasiDetail, transaction);
                        if (deleted > 0) { konsinyasiDetail.Deleted = true; }

                        // tambahkan affected rows-nya
                        affected += deleted;

                        // next loop
                        continue;
                    }

                    // Item For Update
                    if (konsinyasiDetail.ID_Konsinyasi_Detail != -1)
                    {
                        // ==============================================================================
                        // Proses Update
                        // 1. Mengurangi stok yg sudah pernah ditambahkan akibat konsinyasi
                        // 2. Update info detail konsinyasi
                        // 3. Tambahkan stok sesuai hasil konsinyasi yg baru
                        // ==============================================================================
                        sql =
                            @"UPDATE stok_item SET
                                stok = stok - (
                                    SELECT kd.jumlah * si.konversi_jumlah FROM konsinyasi_detail kd
                                    JOIN satuan_item si ON si.id_item = kd.id_item AND si.id_satuan = kd.id_satuan
                                    WHERE kd.id_konsinyasi_detail = @id_konsinyasi_detail)
                            WHERE id_item = @id_item AND id_departemen = @id_departemen";
                        affected += connection.Execute(sql, new {
                            id_konsinyasi_detail = konsinyasiDetail.ID_Konsinyasi_Detail,
                            id_item = konsinyasiDetail.ID_Item,
                            id_departemen = konsinyasi.ID_Departemen
                        }, transaction);


                        sql =
                            @"UPDATE konsinyasi_detail SET
                                id_satuan = @id_satuan, 
                                jumlah = @jumlah, 
                                harga_beli = @harga_beli,
                                sub_total = @sub_total
                            WHERE id_konsinyasi_detail = @id_konsinyasi_detail";
                        affected += connection.Execute(sql, konsinyasiDetail, transaction);

                        sql =
                            @"UPDATE stok_item SET
                                stok = stok + (
                                    SELECT kd.jumlah * si.konversi_jumlah FROM konsinyasi_detail kd
                                    JOIN satuan_item si ON si.id_item = kd.id_item AND si.id_satuan = kd.id_satuan
                                    WHERE kd.id_konsinyasi_detail = @id_konsinyasi_detail)
                            WHERE id_item = @id_item AND id_departemen = @id_departemen";
                        affected += connection.Execute(sql, new {
                            id_konsinyasi_detail = konsinyasiDetail.ID_Konsinyasi_Detail,
                            id_item = konsinyasiDetail.ID_Item,
                            id_departemen = konsinyasi.ID_Departemen
                        }, transaction);

                        // next loop
                        continue;
                    }

                    // Item For Insert
                    if (konsinyasiDetail.ID_Konsinyasi_Detail == -1)
                    {
                        // Insert konsinyasi detail
                        sql =
                           @"INSERT INTO konsinyasi_detail
                           (id_konsinyasi, id_item, id_satuan, jumlah, harga_beli, sub_total)
                           VALUES
                           (@id_konsinyasi,@id_item,@id_satuan,@jumlah,@harga_beli,@sub_total)";

                        affected += connection.Execute(sql, konsinyasiDetail, transaction);

                        // Ambil PK id_konsinyasi_detail
                        konsinyasiDetail.ID_Konsinyasi_Detail = connection.ExecuteScalar<int>("SELECT last_insert_id()", null, transaction);

                        // update stok
                        sql =
                            @"UPDATE stok_item s 
                                JOIN satuan_item si ON si.id_item = s.id_item
                            SET s.stok = s.stok + (@jumlah * si.konversi_jumlah)
                            WHERE 
	                            s.id_departemen = @id_departemen AND
                                s.id_item = @id_item AND
                                si.id_satuan = @id_satuan";

                        affected += connection.Execute(sql, new {
                            jumlah = konsinyasiDetail.Jumlah,
                            id_departemen = konsinyasi.ID_Departemen,
                            id_item = konsinyasiDetail.ID_Item,
                            id_satuan = konsinyasiDetail.ID_Satuan
                        }, transaction);
                    }
                }
            }

            return (affected > 0);
        }

        public static Konsinyasi GetSingle(IDbConnection dbConnection, int id_konsinyasi, bool withDetails = false, bool withSupplierRef = false, bool withUserRef = false, bool withDepartemenRef = false)
        {
            var sql = "select * from konsinyasi where id_konsinyasi = @id_konsinyasi";

            var konsinyasi = dbConnection.Query<Konsinyasi>(sql, new { id_konsinyasi = id_konsinyasi }).SingleOrDefault();

            if (konsinyasi != null)
            {
                if (withDetails)
                    konsinyasi.KonsinyasiDetails = KonsinyasiDetail.GetListOfKonsinyasi(dbConnection, konsinyasi);

                if (withSupplierRef)
                    konsinyasi.Supplier = Model.Supplier.GetSingle(dbConnection, konsinyasi.ID_Supplier);

                if (withUserRef)
                    konsinyasi.User = Model.User.GetSingle(dbConnection, konsinyasi.ID_User);

                if (withDepartemenRef)
                    konsinyasi.Departemen = Model.Departemen.GetSingle(dbConnection, konsinyasi.ID_Departemen);
            }

            return konsinyasi;
        }

        public static bool Delete(IDbTransaction transaction, Konsinyasi konsinyasi)
        {
            var affected = 0;

            // Kembalikan stok item sesuai hasil konsinyasi
            var sql =
                @"UPDATE stok_item SET stok = stok - (@jumlah * @konversi_jumlah) 
                WHERE id_item = @id_item AND id_departemen = @id_departemen";

            foreach (var konsinyasiDetail in konsinyasi.KonsinyasiDetails)
            {
                affected += transaction.Connection.Execute(sql, new
                {
                    jumlah = konsinyasiDetail.Jumlah,
                    konversi_jumlah = konsinyasiDetail.SatuanItem.Konversi_Jumlah,
                    id_item = konsinyasiDetail.ID_Item,
                    id_departemen = konsinyasi.ID_Departemen
                }, transaction);
            }

            // Hapus tiap detail konsinyasi
            var sql2 = "DELETE FROM konsinyasi_detail WHERE id_konsinyasi = @id_konsinyasi";
            affected += transaction.Connection.Execute(sql2, konsinyasi, transaction);

            // Hapus konsinyasi
            var sql3 = "DELETE FROM konsinyasi WHERE id_konsinyasi = @id_konsinyasi";
            affected += transaction.Connection.Execute(sql3, konsinyasi, transaction);

            return (affected > 0);
        }

        public static bool AddPembayaran(IDbTransaction transaction, Model.KonsinyasiPembayaran konsinyasiPembayaran)
        {
            var affected = 0;

            // Update jumlah item yg sudah dibayar
            foreach (var kpd in konsinyasiPembayaran.KonsinyasiPembayaranDetails)
            {
                var sql = 
                    "UPDATE konsinyasi_detail SET jumlah_bayar = jumlah_bayar + @jumlah_item WHERE id_konsinyasi_detail = @id_konsinyasi_detail";

                affected += transaction.Connection.Execute(sql, new {
                    jumlah_item = kpd.Jumlah_Item,
                    id_konsinyasi_detail = kpd.ID_Konsinyasi_Detail
                }, transaction);
            }

            // Cek kelunasan

            // Tambah pembayaran
            var sql2 = "UPDATE konsinyasi SET total_pembayaran = total_pembayaran + @jumlah_bayar WHERE id_konsinyasi = @id_konsinyasi";

            affected += transaction.Connection.Execute(sql2, new { 
                jumlah_bayar = konsinyasiPembayaran.Jumlah_Bayar
            }, transaction);

            return (affected > 0);
        }
    }

    public class KonsinyasiDetail
    {
        public int ID_Konsinyasi_Detail { get; set; }
        public int ID_Konsinyasi { get; set; }
        public int ID_Item { get; set; }
        public int ID_Satuan { get; set; }

        public int Jumlah { get; set; }
        public int Harga_Beli { get; set; }
        public int Sub_Total { get; set; }
        
        /// <summary>
        /// Jumlah retur dalam konversi transaksi
        /// </summary>
        public float Jumlah_Retur { get; set; }

        /// <summary>
        /// Jumlah keluar dalam konversi transaksi
        /// </summary>
        public float Jumlah_Keluar { get; set; }

        /// <summary>
        /// Jumlah bayar dalam konversi transaksi
        /// </summary>
        public float Jumlah_Bayar { get; set; }

        // Untuk kebutuhan update data
        public int Old_Jumlah { get; set; }
        public int Old_ID_Satuan { get; set; }

        // reference object
        public Model.Konsinyasi Konsinyasi { get; set; }
        public Model.Item Item { get; set; }
        public Model.Satuan Satuan { get; set; }
        public Model.SatuanItem SatuanItem { get; set; }

        // Status object
        public bool ForDelete { get; set; }
        public bool Deleted { get; set; }

        public static List<KonsinyasiDetail> GetListOfKonsinyasi(IDbConnection dbConnection, Model.Konsinyasi konsinyasi)
        {
            var sql = "select * from konsinyasi_detail where id_konsinyasi = @id_konsinyasi";

            var konsinyasiDetails = dbConnection.Query<Model.KonsinyasiDetail>(sql, konsinyasi).ToList();

            // Mendapatkan SatuanItemViews
            foreach (var konsinyasiDetail in konsinyasiDetails)
            {
                var sql2 = "select id_item, kode_item, nama_item from item where id_item = @id_item";
                konsinyasiDetail.Item = dbConnection.Query<Model.Item>(sql2, konsinyasiDetail).First();
                konsinyasiDetail.Item.SatuanItemViews = Model.Item.GetSatuanItemViews(dbConnection, konsinyasiDetail.ID_Item);
                konsinyasiDetail.SatuanItem = Model.SatuanItem.GetSingle(dbConnection, konsinyasiDetail.ID_Item, konsinyasiDetail.ID_Satuan);
            }

            return konsinyasiDetails;
        }

        
    }
}
