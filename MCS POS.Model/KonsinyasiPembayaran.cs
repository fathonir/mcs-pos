using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;

namespace MCS_POS.Model
{
    public class KonsinyasiPembayaran
    {
        public int ID_Konsinyasi_Pembayaran { get; set; }
        public int ID_Departemen { get; set; }
        public int ID_Konsinyasi { get; set; }
        public int ID_User { get; set; }
        public int ID_Bank { get; set; }

        public string Kode_Transaksi { get; set; }
        public DateTime Waktu_Transaksi { get; set; }
        public bool Is_Tunai { get; set; }

        public float Jumlah_Bayar { get; set; }
        public float Jumlah_Item { get; set; }

        public List<KonsinyasiPembayaranDetail> KonsinyasiPembayaranDetails { get; set; }

        // reference object
        public Departemen Departemen { get; set; }
        public Konsinyasi Konsinyasi { get; set; }
        public User User { get; set; }
        public Bank Bank { get; set; }

        public Guid GUID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public static string GenerateKodeTransaksi(System.Data.IDbConnection dbConnection, Model.Departemen departemen, List<Config> configs)
        {
            // mendapatkan format, default = [COUNTER]/HKI/[DEPARTEMEN]/[BLN][THN]
            var formatKode = configs.First(s => s.Nama == Model.Config.FORMAT_KODE_KONSINYASI_PEMBAYARAN).Nilai;

            // digit counter, default = 4
            var digitCounter = int.Parse(configs.First(s => s.Nama == Model.Config.DIGIT_COUNTER_KONSINYASI_PEMBAYARAN).Nilai);

            // reset perulangan counter, default = BULAN
            var resetCounter = configs.First(s => s.Nama == Model.Config.RESET_COUNTER_KONSINYASI_PEMBAYARAN).Nilai;

            // mendapatkan jumlah transaksi dalam periode reset
            var transactionCount = 0;

            if (resetCounter == "BULAN")
            {
                var sql = @"
                    SELECT Count(*) AS count FROM konsinyasi_pembayaran
                    WHERE id_departemen = @id_departemen AND Year(waktu_transaksi) = @tahun AND Month(waktu_transaksi) = @bulan";

                transactionCount = dbConnection.ExecuteScalar<int>(sql, new {
                    id_departemen = departemen.ID_Departemen,
                    tahun = DateTime.Now.Year,
                    bulan = DateTime.Now.Month
                });
            }

            if (resetCounter == "HARI")
            {
                var sql = @"
                    SELECT Count(*) AS count FROM konsinyasi_pembayaran
                    WHERE id_departemen = @id_departemen AND Year(waktu_transaksi) = @tahun AND Month(waktu_transaksi) = @bulan AND Day(waktu_transaksi) = @tanggal";

                transactionCount = dbConnection.ExecuteScalar<int>(sql, new {
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
                dbConnection.Execute("UPDATE sequence SET next_value = 1 WHERE sequence_name = 'konsinyasi_pembayaran'");
            }

            string resultKodeTransaksi = "";

            // Generate dan Test kode
            do
            {
                // ambil sequence
                int next_value = dbConnection.ExecuteScalar<int>("SELECT next_value FROM sequence WHERE sequence_name = 'konsinyasi_pembayaran'");

                // increment sequence : di pindah ketika simpan Transaksi Baru
                dbConnection.Execute("UPDATE sequence SET next_value = next_value + increment WHERE sequence_name = 'konsinyasi_pembayaran'");

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
            } while (dbConnection.ExecuteScalar<int>("SELECT count(*) FROM konsinyasi_pembayaran WHERE kode_transaksi = '" + resultKodeTransaksi + "'") > 0);

            // kembalikan hasil
            return resultKodeTransaksi;
        }

        public static bool Add(IDbTransaction t, Model.KonsinyasiPembayaran kp)
        {
            var sql =
                @"INSERT INTO konsinyasi_pembayaran (
                    id_departemen, id_user, id_konsinyasi, kode_transaksi, waktu_transaksi, jumlah_bayar, jumlah_item, is_tunai, id_bank, guid, created)
                VALUES (
                    @id_departemen,@id_user,@id_konsinyasi,@kode_transaksi,@waktu_transaksi,@jumlah_bayar,@jumlah_item,@is_tunai,@id_bank,@guid,@created)";

            var affected = t.Connection.Execute(sql, kp, t);

            // Jika berhasil insert
            if (affected > 0)
            {
                // Ambil (PK) ID_konsinyasi_pembayaran yg berhasil terinsert
                kp.ID_Konsinyasi_Pembayaran = t.Connection.ExecuteScalar<int>("SELECT last_insert_id()", null, t);

                // Tambahkan detail-detail ke database
                foreach (var kpd in kp.KonsinyasiPembayaranDetails)
                {
                    // Set FK Id Konsinyasi Pembayaran
                    kpd.ID_Konsinyasi_Pembayaran = kp.ID_Konsinyasi_Pembayaran;

                    var sql2 =
                        @"INSERT INTO konsinyasi_pembayaran_detail (
                            id_konsinyasi_pembayaran, id_konsinyasi_detail, jumlah_item, jumlah_sub_total)
                        VALUES (
                            @id_konsinyasi_pembayaran,@id_konsinyasi_detail,@jumlah_item,@jumlah_sub_total)";

                    affected += t.Connection.Execute(sql2, kpd, t);

                    // Ambil (PK) id_konsinyasi_pembayaran_detail yg berhasil terinsert
                    kpd.ID_Konsinyasi_Pembayaran_Detail = t.Connection.ExecuteScalar<int>("SELECT last_insert_id()", null, t);
                }
            }

            return (affected > 0);
        }
    }

    public class KonsinyasiPembayaranDetail
    {
        public int ID_Konsinyasi_Pembayaran_Detail { get; set; }
        public int ID_Konsinyasi_Pembayaran { get; set; }
        public int ID_Konsinyasi_Detail { get; set; }

        public float Jumlah_Item { get; set; }
        public float Jumlah_Sub_Total { get; set; }

        // Reference Object
        public KonsinyasiPembayaran KonsinyasiPembayaran { get; set; }
        public KonsinyasiDetail KonsinyasiDetail { get; set; }
    }
}
