using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MCS_POS.Model
{
    public class Penjualan
    {
        public int ID_Penjualan { get; set; }
        public int ID_Departemen { get; set; }
        public int ID_User { get; set; }
        public int ID_Customer { get; set; }

        public string Kode_Transaksi { get; set; }
        public DateTime Waktu_Transaksi { get; set; }
        public int? ID_Pesanan_Penjualan { get; set; }
        public int Biaya_Lain { get; set; }
        public int Biaya_Potongan { get; set; }
        public int Total_Biaya { get; set; }
        public int Total_Biaya_Akhir { get; set; }
        public int Jumlah_Item { get; set; }
        public int Jumlah_Ragam_Item { get; set; }
        public int Bayar_Tunai { get; set; }
        public int Bayar_Kembali { get; set; }
        public bool Is_Dibayar { get; set; }
        public bool Is_Saved { get; set; }
        public string Keterangan_Save { get; set; }

        // Kolom2 Refund
        public bool Is_Refund { get; set; }
        public int Jumlah_Item_Refund { get; set; }
        public DateTime Waktu_Refund { get; set; }
        public int ID_User_Refund { get; set; }
        public int Biaya_Potongan_Refund { get; set; }
        public int Total_Biaya_Refund { get; set; }

        // Column Referensi
        public string Nama_User_Ref { get; set; }

        // Object Referensi
        public User User { get; set; }
        public User UserRefund { get; set; }
        public Departemen Departemen { get; set; }
        public Customer Customer { get; set; }
        public List<PenjualanDetail> PenjualanDetails { get; set; }

        public class PenjualanKasirView
        {
            public int ID_Penjualan { get; set; }
            public string Kode_Transaksi { get; set; }
            public DateTime Waktu_Transaksi { get; set; }
            public string Nama_User { get; set; }
            public int Jumlah_Item { get; set; }
            public int Jumlah_Item_Refund { get; set; }
            public int Total_Biaya_Akhir { get; set; }
        }

        public static Penjualan GetSingle(IDbConnection dbConnection, int id_penjualan, bool withDetails = true, bool withCustomerRef = true, bool withUserRef = true, bool withUserRefundRef = true, bool withDepartemenRef = true)
        {
            var sql = "SELECT * FROM penjualan WHERE id_penjualan = @id_penjualan";
            
            var penjualan = dbConnection.Query<Penjualan>(sql, new { id_penjualan = id_penjualan }).SingleOrDefault();

            if (penjualan != null)
            {
                if (withDetails)
                {
                    penjualan.PenjualanDetails = PenjualanDetail.GetListOfPenjualan(dbConnection, penjualan);
                }

                if (withCustomerRef)
                {
                    penjualan.Customer = Customer.GetSingle(dbConnection, penjualan.ID_Customer);
                }

                if (withUserRef)
                {
                    penjualan.User = User.GetSingle(dbConnection, penjualan.ID_User);
                }

                if (withUserRefundRef)
                {
                    if (penjualan.ID_User_Refund != 0)
                        penjualan.UserRefund = User.GetSingle(dbConnection, penjualan.ID_User_Refund);
                }

                if (withDepartemenRef)
                {
                    penjualan.Departemen = Departemen.GetSingle(dbConnection, penjualan.ID_Departemen);
                }
            }
            
            return penjualan;
        }

        public static Penjualan GetActive(IDbConnection dbConnection, Departemen departemen, User user)
        {
            var sql =
                @"SELECT * FROM penjualan 
                WHERE 
	                id_departemen = @id_departemen AND 
                    id_user = @id_user AND 
	                is_dibayar = 0 AND 
                    is_saved = 0
                LIMIT 1";

            var penjualan = dbConnection.Query<Penjualan>(sql, new
            {
                id_departemen = departemen.ID_Departemen,
                id_user = user.ID_User
            }).FirstOrDefault();

            // Jika ada
            if (penjualan != null)
            {
                // Assign Departemen & departemen
                penjualan.Departemen = departemen;
                penjualan.User = user;

                // Get Details
                penjualan.PenjualanDetails = PenjualanDetail.GetListOfPenjualan(dbConnection, penjualan);
            }

            return penjualan;
        }

        public static bool Add(IDbConnection dbConnection, Penjualan penjualan)
        {
            var sql =
                @"INSERT INTO penjualan (id_departemen, id_user, id_customer, kode_transaksi, waktu_transaksi) 
                VALUES (@id_departemen,@id_user,@id_customer,@kode_transaksi,@waktu_transaksi)";
            var result = dbConnection.Execute(sql, penjualan);

            if (result > 0)
            {
                // Get last insert ID
                penjualan.ID_Penjualan = dbConnection.ExecuteScalar<int>("SELECT last_insert_id()");

                return true;
            }
            else return false;
        }

        public static bool Bayar(IDbTransaction transaction, Penjualan penjualan)
        {
            return false;
        }

        public static bool Update(IDbTransaction transaction, Penjualan penjualan)
        {
            var sql =
                @"UPDATE penjualan SET 
                    kode_transaksi = @kode_transaksi,
                    jumlah_item = @jumlah_item,
                    biaya_lain = @biaya_lain,
                    biaya_potongan = @biaya_potongan,
                    total_biaya = @total_biaya,
                    total_biaya_akhir = @total_biaya_akhir,
                    is_dibayar = @is_dibayar,
                    is_saved = @is_saved,
                    keterangan_save = @keterangan_save,
                    waktu_transaksi = @waktu_transaksi
                WHERE id_penjualan = @id_penjualan";

            var affected = transaction.Connection.Execute(sql, penjualan, transaction);

            // Jika dibayar, maka stok baru di update
            if (affected > 0 && penjualan.Is_Dibayar)
            {
                foreach (var penjualanDetail in penjualan.PenjualanDetails)
                {
                    // Update stok setelah penjualan
                    var sql2 =
                        @"UPDATE stok_item stok 
	                        JOIN penjualan_detail pd on stok.id_item = pd.id_item
                            JOIN penjualan p on p.id_penjualan = pd.id_penjualan AND stok.id_departemen = p.id_departemen
                            JOIN satuan_item si on si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                        SET
	                        stok.stok = stok.stok - (pd.jumlah * si.konversi_jumlah)
                        WHERE id_penjualan_detail = @id_penjualan_detail";
                    affected += transaction.Connection.Execute(sql2, penjualanDetail, transaction);


                    // ========================================================
                    // Tambahan proses untuk barang konsinyasi
                    // ========================================================
                    // Cek apakah item barang konsinyasi
                    var isKonsinyasi = transaction.Connection.ExecuteScalar<bool>(
                        "SELECT is_konsinyasi FROM item WHERE id_item = @id_item", penjualanDetail, transaction);

                    if (isKonsinyasi)
                    {
                        // Ambil item2 Konsinyasi masuk paling awal (FIFO)
                        // dan sisa jumlahnya masih ada
                        var konsinyasiDetails = transaction.Connection.Query<Model.KonsinyasiDetail>(
                            @"SELECT kd.* from konsinyasi_detail kd
                            JOIN konsinyasi k ON k.id_konsinyasi = kd.id_konsinyasi
                            WHERE k.is_lunas = 0 AND (jumlah - jumlah_retur) > jumlah_keluar AND kd.id_item = @id_item
                            ORDER BY waktu_transaksi ASC", penjualanDetail, transaction);

                        // Ambil satuan item
                        penjualanDetail.SatuanItem = SatuanItem.GetSingle(transaction.Connection, penjualanDetail.ID_Item, penjualanDetail.ID_Satuan);

                        // Sisa yang akan keluar
                        var sisaKeluar = penjualanDetail.Jumlah * penjualanDetail.SatuanItem.Konversi_Jumlah;

                        // Tiap detail konsinyasi yg belum habis di cek semua
                        foreach (var konsinyasiDetail in konsinyasiDetails)
                        {
                            konsinyasiDetail.SatuanItem = SatuanItem.GetSingle(transaction.Connection, konsinyasiDetail.ID_Item, konsinyasiDetail.ID_Satuan);

                            // maksimum konsi keluar dari sisa konsi yg belum keluar
                            var maxKeluar = (konsinyasiDetail.Jumlah - konsinyasiDetail.Jumlah_Retur - konsinyasiDetail.Jumlah_Keluar) * konsinyasiDetail.SatuanItem.Konversi_Jumlah;

                            if (sisaKeluar > maxKeluar)
                            {
                                konsinyasiDetail.Jumlah_Keluar += maxKeluar / konsinyasiDetail.SatuanItem.Konversi_Jumlah;

                                var sql3 = "UPDATE konsinyasi_detail SET jumlah_keluar = @jumlah_keluar WHERE id_konsinyasi_detail = @id_konsinyasi_detail";
                                affected += transaction.Connection.Execute(sql3, konsinyasiDetail, transaction);

                                sisaKeluar -= maxKeluar;
                            }
                            else if (sisaKeluar <= maxKeluar)
                            {
                                konsinyasiDetail.Jumlah_Keluar += sisaKeluar / konsinyasiDetail.SatuanItem.Konversi_Jumlah;
                                
                                var sql3 = "UPDATE konsinyasi_detail SET jumlah_keluar = @jumlah_keluar WHERE id_konsinyasi_detail = @id_konsinyasi_detail";
                                affected += transaction.Connection.Execute(sql3, konsinyasiDetail, transaction);

                                sisaKeluar = 0;
                            }

                            // Jika sudah tidak ada sisa lagi, keluar dari loop Konsi FIFO
                            if (sisaKeluar == 0.0f)
                                break;
                        }
                    }
                }
            }

            return (affected > 0);
        }

        public static bool UpdateForRefund(IDbTransaction transaction, Penjualan penjualan)
        {
            // Proses Penjualan
            var sql =
                @"UPDATE penjualan SET
                    total_biaya = @total_biaya,
                    biaya_potongan_refund = @biaya_potongan_refund,
                    total_biaya_refund = @total_biaya_refund,
                    total_biaya_akhir = @total_biaya_akhir,
                    is_refund = @is_refund,
                    waktu_refund = @waktu_refund,
                    jumlah_item_refund = @jumlah_item_refund
                WHERE id_penjualan = @id_penjualan";
            
            var affected = transaction.Connection.Execute(sql, penjualan, transaction);

            if (affected > 0)
            {
                // Reset stok lama
                var sql1 =
                    @"UPDATE stok_item stok 
	                    JOIN penjualan_detail pd on stok.id_item = pd.id_item
                        JOIN penjualan p on p.id_penjualan = pd.id_penjualan AND stok.id_departemen = p.id_departemen
                        JOIN satuan_item si on si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                    SET
	                    stok.stok = stok.stok - (pd.jumlah_refund * si.konversi_jumlah)
                    WHERE id_penjualan_detail = @id_penjualan_detail";

                // Update Penjualan detail
                var sql2 = 
                    @"UPDATE penjualan_detail SET
                        is_refund = @is_refund, 
                        jumlah_refund = @jumlah_refund,
                        harga_refund = @harga_refund,
                        sub_total = @sub_total,
                        potongan_refund = if(@is_refund, (harga_jual - @harga_refund), 0)
                    WHERE id_penjualan_detail = @id_penjualan_detail";

                // update stok baru
                var sql3 =
                    @"UPDATE stok_item stok 
	                    JOIN penjualan_detail pd on stok.id_item = pd.id_item
                        JOIN penjualan p on p.id_penjualan = pd.id_penjualan AND stok.id_departemen = p.id_departemen
                        JOIN satuan_item si on si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                    SET
	                    stok.stok = stok.stok + (pd.jumlah_refund * si.konversi_jumlah)
                    WHERE id_penjualan_detail = @id_penjualan_detail";

                // Proses Tiap Item
                foreach (var item in penjualan.PenjualanDetails)
                {
                    affected += transaction.Connection.Execute(sql1, item, transaction);
                    affected += transaction.Connection.Execute(sql2, item, transaction);
                    affected += transaction.Connection.Execute(sql3, item, transaction);
                }
            }

            return (affected > 0);
        }

        public static bool SetRefund(IDbTransaction t, int id_penjualan, int id_user)
        {
            var sql = "UPDATE penjualan SET is_refund = 1, id_user_refund = @id_user WHERE id_penjualan = @id_penjualan";
            return (t.Connection.Execute(sql, new { id_user = id_user, id_penjualan = id_penjualan }) > 0);
        }

        public static string GenerateKodeTransaksi(IDbConnection dbConnection, Departemen departemen, IEnumerable<Model.Config> settings)
        {
            // mendapatkan format
            var formatKode = settings.First(s => s.Nama == "format_kode_penjualan").Nilai;
            // var formatKode = configIni.GetString("app", "format_kode_penjualan", "[COUNTER]/JL/[DEPARTEMEN]/[BLN][THN]");

            var digitCounter = int.Parse(settings.First(s => s.Nama == "digit_counter_penjualan").Nilai);
            // var digitCounter = configIni.GetInt32("app", "digit_counter_penjualan", 4);

            var resetCounter = settings.First(s => s.Nama == "reset_counter_penjualan").Nilai;
            //var resetCounter = configIni.GetString("app", "reset_counter_penjualan", "BULAN");

            // mendapatkan jumlah transaksi dalam periode reset
            var jumlahTransaksi = 0;

            if (resetCounter == "TAHUN")
            {
                var sql = 
                    @"SELECT count(*) FROM penjualan 
                    WHERE 
                        kode_transaksi is not null AND 
                        id_departemen = @id_departemen AND 
                        year(waktu_transaksi) = @tahun";

                jumlahTransaksi = dbConnection.ExecuteScalar<int>(sql, new
                {
                    id_departemen = departemen.ID_Departemen,
                    tahun = DateTime.Now.Year
                });
            }

            if (resetCounter == "BULAN")
            {
                var sql = 
                    @"SELECT count(*) FROM penjualan WHERE 
                        kode_transaksi is not null AND
                        id_departemen = @id_departemen AND 
                        year(waktu_transaksi) = @tahun AND 
                        month(waktu_transaksi) = @bulan";

                jumlahTransaksi = dbConnection.ExecuteScalar<int>(sql, new
                {
                    id_departemen = departemen.ID_Departemen,
                    tahun = DateTime.Now.Year,
                    bulan = DateTime.Now.Month
                });
            }

            if (resetCounter == "HARI")
            {
                var sql = @"SELECT count(*) FROM penjualan WHERE 
                    kode_transaksi is not null AND
                    id_departemen = @id_departemen AND 
                    year(waktu_transaksi) = @tahun AND 
                    month(waktu_transaksi) = @bulan AND 
                    day(waktu_transaksi) = @tanggal";

                jumlahTransaksi = dbConnection.ExecuteScalar<int>(sql, new
                {
                    id_departemen = departemen.ID_Departemen,
                    tahun = DateTime.Now.Year,
                    bulan = DateTime.Now.Month,
                    tanggal = DateTime.Now.Day
                });
            }

            // jika belum ada
            if (jumlahTransaksi == 0)
            {
                // reset sequence
                dbConnection.Execute("UPDATE sequence SET next_value = 1 WHERE sequence_name = 'penjualan'");
            }

            string resultKodeTransaksi = "";

            // Generate dan Test kode
            do
            {
                // ambil sequence
                int next_value = dbConnection.ExecuteScalar<int>("SELECT next_value FROM sequence WHERE sequence_name = 'penjualan'");

                // increment sequence
                dbConnection.Execute("UPDATE sequence SET next_value = next_value + increment WHERE sequence_name = 'penjualan'");

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
            } while (dbConnection.ExecuteScalar<int>("SELECT count(*) FROM penjualan WHERE kode_transaksi = '" + resultKodeTransaksi + "'") > 0);

            // kembalikan hasil
            return resultKodeTransaksi;
        }

        public static List<PenjualanKasirView> GetListPenjualanKasir(IDbConnection dbConnection, Departemen departemen, int filterDayPast = 0, int id_user = 0, bool is_refund = false)
        {
            string whereTambahan = "";
            
            if (filterDayPast == 0)
            {
                var tglTujuan = DateTime.Now;
                var tglAwal = tglTujuan.ToString("yyyy-MM-dd") + " 00:00:00";
                var tglAkhir = tglTujuan.ToString("yyyy-MM-dd") + " 23:59:59";
                whereTambahan = "AND (p.waktu_transaksi BETWEEN '" + tglAwal + "' AND '" + tglAkhir + "')\n";
            }
            else if (filterDayPast > 0) // kemarin dst
            {
                var tglTujuan = DateTime.Now;
                var tglAwal = tglTujuan.AddDays(-filterDayPast).ToString("yyyy-MM-dd") + " 00:00:00";
                var tglAkhir = tglTujuan.ToString("yyyy-MM-dd") + " 23:59:59";
                whereTambahan = "AND (p.waktu_transaksi BETWEEN '" + tglAwal + "' AND '" + tglAkhir + "')\n";
            }

            // Filter Kasir
            if (id_user > 0)
            {
                whereTambahan += "AND p.id_user = " + id_user + "\n";
            }

            // Filter retur
            if (is_refund)
            {
                whereTambahan += "AND p.is_refund = 1\n";
            }

            // Building Query
            string sql = string.Format(
                @"SELECT id_penjualan, kode_transaksi, waktu_transaksi, nama_user, jumlah_item, jumlah_item_refund, total_biaya_akhir
                FROM penjualan p
                JOIN user u ON u.id_user = p.id_user
                WHERE p.id_departemen = @id_departemen AND p.is_dibayar = 1
                    {1}
                ORDER BY waktu_transaksi DESC", is_refund, whereTambahan);

            // Return hasil dalam bentuk List
            return dbConnection.Query<PenjualanKasirView>(sql, new { id_departemen = departemen.ID_Departemen }).ToList();
        }

        public static bool Delete(IDbTransaction transaction, Penjualan penjualan)
        {
            throw new NotImplementedException();
        }
    }

    public class PenjualanDetail
    {
        public int ID_Penjualan_Detail { get; set; }
        public int ID_Penjualan { get; set; }
        public int ID_Item { get; set; }
        public int ID_Satuan { get; set; }

        public int Jumlah { get; set; }
        public int Harga_Jual { get; set; }
        public int Sub_Total { get; set; }

        // Refund
        public bool Is_Refund { get; set; }
        public int Jumlah_Refund { get; set; }
        public int Harga_Refund { get; set; }
        public int Potongan_Refund { get; set; }

        // String Reference
        public string Kode_Item { get; set; }
        public string Nama_Item { get; set; }
        public string Nama_Satuan { get; set; }

        // Object Reference
        public Penjualan Penjualan { get; set; }
        public Item Item { get; set; }
        public Satuan Satuan { get; set; }
        public SatuanItem SatuanItem { get; set; }

        public static List<PenjualanDetail> GetListOfPenjualan(IDbConnection dbConnection, Penjualan p)
        {
            var sql = 
                @"SELECT 
                    pd.id_penjualan_detail, pd.id_penjualan, pd.id_item, pd.id_satuan,
                    i.kode_item, i.nama_item, s.nama_satuan,
                    pd.jumlah, pd.harga_jual, pd.sub_total,
                    pd.is_refund, pd.jumlah_refund, pd.harga_refund, pd.potongan_refund
                FROM penjualan_detail pd
                JOIN item i on i.id_item = pd.id_item
                JOIN satuan s on s.id_satuan = pd.id_satuan
                WHERE pd.id_penjualan = @id_penjualan
                ORDER BY pd.id_penjualan_detail ASC";

            var penjualanDetails = dbConnection.Query<PenjualanDetail>(sql, new { id_penjualan = p.ID_Penjualan }).ToList();

            foreach (var penjualanDetail in penjualanDetails)
            {
                // Ambil satuan item untuk konversi
                penjualanDetail.SatuanItem = SatuanItem.GetSingle(dbConnection, penjualanDetail.ID_Item, penjualanDetail.ID_Satuan);
            }

            return penjualanDetails;
        }

        public static bool Insert(IDbTransaction transaction, PenjualanDetail pd)
        {
            var sql = 
                @"INSERT INTO penjualan_detail (id_penjualan, id_item, id_satuan, jumlah, harga_jual, sub_total)
                VALUES (@id_penjualan, @id_item, @id_satuan, @jumlah, @harga_jual, @sub_total)";

            var result = transaction.Connection.Execute(sql, pd, transaction);

            if (result > 0)
            {
                // Last insert id -> Primary Key
                pd.ID_Penjualan_Detail = transaction.Connection.ExecuteScalar<int>("SELECT last_insert_id()", null, transaction);

                return true;
            }

            return false;
        }

        public static bool Update(IDbTransaction transaction, PenjualanDetail pd)
        {
            var sql =
                @"UPDATE penjualan_detail SET jumlah = @jumlah, harga_jual = @harga_jual, sub_total = @sub_total WHERE id_penjualan_detail = @id_penjualan_detail";

            return (transaction.Connection.Execute(sql, pd, transaction) > 0);
        }

        public static bool Delete(IDbTransaction transaction, int id_penjualan_detail)
        {
            var sql = "DELETE FROM penjualan_detail WHERE id_penjualan_detail = @id_penjualan_detail";
            return (transaction.Connection.Execute(sql, new { id_penjualan_detail = id_penjualan_detail }, transaction) > 0);
        }
    }
}
