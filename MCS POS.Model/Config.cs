using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MCS_POS.Model
{
    public class Config
    {
        public const string PERIODE_AWAL = "periode_awal";

        public const string FORMAT_KODE_PEMBELIAN = "format_kode_pembelian";
        public const string DIGIT_COUNTER_PEMBELIAN = "digit_counter_pembelian";
        public const string RESET_COUNTER_PEMBELIAN = "reset_counter_pembelian";

        public const string FORMAT_KODE_PENJUALAN = "format_kode_penjualan";
        public const string DIGIT_COUNTER_PENJUALAN = "digit_counter_penjualan";
        public const string RESET_COUNTER_PENJUALAN = "reset_counter_penjualan";

        public const string FORMAT_KODE_TRANSFER = "format_kode_transfer";
        public const string DIGIT_COUNTER_TRANSFER = "digit_counter_transfer";
        public const string RESET_COUNTER_TRANSFER = "reset_counter_transfer";

        public const string FORMAT_KODE_KONSINYASI = "format_kode_konsinyasi";
        public const string DIGIT_COUNTER_KONSINYASI = "digit_counter_konsinyasi";
        public const string RESET_COUNTER_KONSINYASI = "reset_counter_konsinyasi";

        public const string FORMAT_KODE_KONSINYASI_RETUR = "format_kode_konsinyasi_retur";
        public const string DIGIT_COUNTER_KONSINYASI_RETUR = "digit_counter_konsinyasi_retur";
        public const string RESET_COUNTER_KONSINYASI_RETUR = "reset_counter_konsinyasi_retur";

        public const string FORMAT_KODE_KONSINYASI_PEMBAYARAN = "format_kode_konsinyasi_pembayaran";
        public const string DIGIT_COUNTER_KONSINYASI_PEMBAYARAN = "digit_counter_konsinyasi_pembayaran";
        public const string RESET_COUNTER_KONSINYASI_PEMBAYARAN = "reset_counter_konsinyasi_pembayaran";

        public const string CABANG_KODE = "cabang_kode";
        public const string CABANG_NAMA = "cabang_nama";
        public const string CABANG_ALAMAT = "cabang_alamat";
        public const string CABANG_KOTA = "cabang_kota";
        public const string CABANG_TELP = "cabang_telp";


        public string Nama { get; set; }
        public string Nilai { get; set; }

        public static IEnumerable<Config> GetAll(IDbConnection dbConnection)
        {
            return dbConnection.Query<Config>("SELECT * FROM config");
        }

        public static bool Add(IDbTransaction t, Model.Config c)
        {
            const string sql = "INSERT INTO `config` (nama, nilai) VALUES (@nama, @nilai)";
            var affected = t.Connection.Execute(sql, c, t);
            return (affected > 0);
        }

        public static void UpdateMulti(IDbTransaction transaction, IEnumerable<Config> configs)
        {
            const string sql = "UPDATE `config` SET nilai = @nilai WHERE nama = @nama";

            foreach (Config c in configs)
            {
                transaction.Connection.Execute(sql, c, transaction);
            }
        }

        public static void InitSequence(IDbTransaction transaction, string sequenceName)
        {
            // ambil jumlah row
            var count = transaction.Connection.
                ExecuteScalar<int>("SELECT COUNT(*) FROM sequence WHERE sequence_name = '" + sequenceName + "'", null, transaction);

            // Jika belum ada
            if (count == 0)
            {
                // tambahkan
                transaction.Connection.
                    Execute("INSERT INTO sequence (sequence_name) VALUES ('" + sequenceName + "')", null, transaction);
            }
        }

        public static void InitConfig(IDbTransaction transaction, List<Config> configs, string configName, object value)
        {
            if (configs.FirstOrDefault(c => c.Nama == configName) == null)
            {
                var config = new Model.Config() { Nama = configName, Nilai = value.ToString() };
                configs.Add(config);
                Model.Config.Add(transaction, config);
            }
        }
    }
}
