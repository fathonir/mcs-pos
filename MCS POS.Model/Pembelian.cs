using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MCS_POS.Model
{
    public class Pembelian
    {
        public int ID_Pembelian { get; set; }
        public int ID_Departemen { get; set; }
        public int ID_User { get; set; }
        public int ID_Supplier { get; set; }

        public string Kode_Transaksi { get; set; }
        public DateTime Waktu_Transaksi { get; set; }
        public int Biaya_Lain { get; set; }
        public int Biaya_Potongan { get; set; }
        public int Total_Biaya { get; set; }
        public int Total_Biaya_Akhir { get; set; }
        public int Jumlah_Item { get; set; }

        // References
        public Model.Departemen Departemen { get; set; }
        public Model.User User { get; set; }
        public Model.Supplier Supplier { get; set; }
        public List<Model.PembelianDetail> PembelianDetails { get; set; }

        public Guid GUID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public static bool Add(IDbTransaction t, Pembelian p)
        {
            var sql =
                @"INSERT INTO pembelian 
                (id_departemen, id_user, id_supplier, kode_transaksi, waktu_transaksi, biaya_lain, biaya_potongan, total_biaya, total_biaya_akhir, jumlah_item, guid)
                VALUES
                (@id_departemen,@id_user,@id_supplier,@kode_transaksi,@waktu_transaksi,@biaya_lain,@biaya_potongan,@total_biaya,@total_biaya_akhir,@jumlah_item,@guid)";

            var affected = t.Connection.Execute(sql, p, t);

            // Jika berhasil insert
            if (affected > 0)
            {
                // Ambil ID_pembelian yg berhasil terinsert
                p.ID_Pembelian = t.Connection.ExecuteScalar<int>("SELECT last_insert_id()", null, t);

                // Tambahkan detail-detail ke database
                foreach (var pd in p.PembelianDetails)
                {
                    // Set FK ID_Pembelian
                    pd.ID_Pembelian = p.ID_Pembelian;

                    // SQL insert detail pembelian
                    var sql2 = 
                        @"INSERT INTO pembelian_detail
                        (id_pembelian, id_item, id_satuan, jumlah, harga_beli, sub_total)
                        VALUES
                        (@id_pembelian,@id_item,@id_satuan,@jumlah,@harga_beli,@sub_total)";

                    // Eksekusi Insert detail pembelian
                    affected += t.Connection.Execute(sql2, pd, t);

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
                    affected += t.Connection.Execute(sql3, new { 
                        jumlah = pd.Jumlah,
                        id_departemen = p.ID_Departemen,
                        id_item = pd.ID_Item,
                        id_satuan = pd.ID_Satuan
                    }, t);
                }

                // Tambahkan increment pembelian
                affected += t.Connection.Execute("UPDATE sequence SET next_value = next_value + increment WHERE sequence_name = 'pembelian'");
            }

            return (affected > 0);
        }

        public static bool Update(IDbTransaction t, Pembelian p)
        {
            // Update informasi pembelian
            var sql = 
                @"UPDATE pembelian SET
                    waktu_transaksi = @waktu_transaksi,
                    id_supplier = @id_supplier,
                    jumlah_item = @jumlah_item,
                    total_biaya = @total_biaya,
                    biaya_potongan = @biaya_potongan,
                    biaya_lain = @biaya_lain,
                    total_biaya_akhir = @total_biaya_akhir,
                    modified = @modified
                WHERE id_pembelian = @id_pembelian";

            var affected = t.Connection.Execute(sql, p, t);

            // =================================================
            // Urutan proses data row : DELETE > UPDATE > INSERT
            // =================================================

            foreach (var pembelianDetail in p.PembelianDetails)
            {
                if (pembelianDetail.ForDelete)
                {
                    // ==============================================================================
                    // Mengurangi stok yg sudah pernah ditambahkan akibat pembelian
                    // STOK = STOK - (JUMLAH * KONVERSI)
                    // ==============================================================================
                    sql =
                        @"UPDATE stok_item SET
                            stok = stok - (
                                SELECT pd.jumlah * si.konversi_jumlah FROM pembelian_detail pd
                                JOIN satuan_item si ON si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                                WHERE pd.id_pembelian_detail = @id_pembelian_detail)
                        WHERE id_item = @id_item AND id_departemen = @id_departemen";
                    affected += t.Connection.Execute(sql, new { 
                        id_pembelian_detail = pembelianDetail.ID_Pembelian_Detail,
                        id_item = pembelianDetail.ID_Item,
                        id_departemen = p.ID_Departemen
                    }, t);

                    // Hapus Item
                    sql = "DELETE FROM pembelian_detail WHERE id_pembelian_detail = " + pembelianDetail.ID_Pembelian_Detail;
                    var deleted = t.Connection.Execute(sql, null, t);
                    if (deleted > 0) { pembelianDetail.Deleted = true; }

                    // tambahkan affected rows-nya
                    affected += deleted;

                    // next loop
                    continue;
                }

                // Item For Update
                if (pembelianDetail.ID_Pembelian_Detail != -1)
                {
                    // ==============================================================================
                    // Proses Update
                    // 1. Mengurangi stok yg sudah pernah ditambahkan akibat pembelian
                    // 2. Update info detail pembelian
                    // 3. Tambahkan stok sesuai hasil pembelian yg baru
                    // ==============================================================================
                    sql =
                        @"UPDATE stok_item SET
                            stok = stok - (
                                SELECT pd.jumlah * si.konversi_jumlah FROM pembelian_detail pd
                                JOIN satuan_item si ON si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                                WHERE pd.id_pembelian_detail = @id_pembelian_detail)
                        WHERE id_item = @id_item AND id_departemen = @id_departemen";
                    affected += t.Connection.Execute(sql, new { 
                        id_pembelian_detail = pembelianDetail.ID_Pembelian_Detail,
                        id_item = pembelianDetail.ID_Item,
                        id_departemen = p.ID_Departemen
                    }, t);


                    sql = 
                        @"UPDATE pembelian_detail SET
                            id_satuan = @id_satuan, 
                            jumlah = @jumlah, 
                            harga_beli = @harga_beli,
                            sub_total = @sub_total
                        WHERE id_pembelian_detail = @id_pembelian_detail";
                    affected += t.Connection.Execute(sql, pembelianDetail, t);

                    sql =
                        @"UPDATE stok_item SET
                            stok = stok + (
                                SELECT pd.jumlah * si.konversi_jumlah FROM pembelian_detail pd
                                JOIN satuan_item si ON si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                                WHERE pd.id_pembelian_detail = @id_pembelian_detail)
                        WHERE id_item = @id_item AND id_departemen = @id_departemen";
                    affected += t.Connection.Execute(sql, new { 
                        id_pembelian_detail = pembelianDetail.ID_Pembelian_Detail,
                        id_item = pembelianDetail.ID_Item,
                        id_departemen = p.ID_Departemen
                    }, t);

                    // next loop
                    continue;
                }


                // Item For Insert
                if (pembelianDetail.ID_Pembelian_Detail == -1)
                {
                    // Insert pembelian detail
                    sql =
                       @"INSERT INTO pembelian_detail
                       (id_pembelian, id_item, id_satuan, jumlah, harga_beli, sub_total)
                       VALUES
                       (@id_pembelian,@id_item,@id_satuan,@jumlah,@harga_beli,@sub_total)";

                    affected += t.Connection.Execute(sql, pembelianDetail, t);

                    // Ambil PK id_pembelian_detail
                    pembelianDetail.ID_Pembelian_Detail = t.Connection.ExecuteScalar<int>("SELECT last_insert_id()", null, t);

                    // update stok
                    sql =
                        @"UPDATE stok_item s 
                            JOIN satuan_item si ON si.id_item = s.id_item
                        SET s.stok = s.stok + (@jumlah * si.konversi_jumlah)
                        WHERE 
	                        s.id_departemen = @id_departemen AND
                            s.id_item = @id_item AND
                            si.id_satuan = @id_satuan";

                    affected += t.Connection.Execute(sql, new { 
                        jumlah = pembelianDetail.Jumlah,
                        id_departemen = p.ID_Departemen,
                        id_item = pembelianDetail.ID_Item,
                        id_satuan = pembelianDetail.ID_Satuan
                    }, t);
                }
            }

            /*
            if (affected > 0)
            {
                foreach (var pd in p.PembelianDetails)
                {
                    // Item baru
                    if (pd.ID_Pembelian_Detail == -1)
                    {

                        // SQL insert detail pembelian
                        var sql2 =
                            @"INSERT INTO pembelian_detail
                                (id_pembelian, id_item, id_satuan, jumlah, harga_beli, sub_total)
                                VALUES
                                (@id_pembelian,@id_item,@id_satuan,@jumlah,@harga_beli,@sub_total)";

                        // Eksekusi Insert detail pembelian
                        affected += t.Connection.Execute(sql2, pd, t);

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
                        affected += t.Connection.Execute(sql3, new
                        {
                            jumlah = pd.Jumlah,
                            id_departemen = p.ID_Departemen,
                            id_item = pd.ID_Item,
                            id_satuan = pd.ID_Satuan
                        }, t);
                    }
                    else // Item lama
                    {
                        // SQL reset stok detail pembelian
                        var sql2 =
                            @"UPDATE stok_item SET
	                            stok = stok - (
		                            SELECT pd.jumlah * si.konversi_jumlah FROM pembelian_detail pd
		                            JOIN satuan_item si ON si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                                    WHERE pd.id_pembelian_detail = @id_pembelian_detail)
                            WHERE 
	                            id_item = @id_item AND
                                id_departemen = @id_departemen";

                        // Eksekusi reset stok detail pembelian
                        affected += t.Connection.Execute(sql2, new {
                            id_pembelian_detail = pd.ID_Pembelian_Detail,
                            id_item = pd.ID_Item,
                            id_departemen = p.ID_Departemen
                        }, t);

                        // SQL update detail pembelian
                        var sql3 =
                            @"UPDATE pembelian_detail SET
                                id_satuan = @id_satuan, 
                                jumlah = @jumlah, 
                                harga_beli = @harga_beli,
                                sub_total = @sub_total
                            WHERE id_pembelian_detail = @id_pembelian_detail";

                        // Eksekusi update detail pembelian
                        affected += t.Connection.Execute(sql3, pd, t);

                        // SQL Update stok
                        var sql4 =
                            @"UPDATE stok_item s 
                                JOIN satuan_item si ON si.id_item = s.id_item
                            SET s.stok = s.stok + (@jumlah * si.konversi_jumlah)
                            WHERE 
	                            s.id_departemen = @id_departemen AND
                                s.id_item = @id_item AND
                                si.id_satuan = @id_satuan";

                        // Eksekusi update stok
                        affected += t.Connection.Execute(sql4, new
                        {
                            jumlah = pd.Jumlah,
                            id_departemen = p.ID_Departemen,
                            id_item = pd.ID_Item,
                            id_satuan = pd.ID_Satuan
                        }, t);
                    }
                }
            }
            **/

            return (affected > 0);
        }

        public static Pembelian GetSingle(IDbConnection dbConnection, int id_pembelian, bool withDetails = true, bool withSupplierRef = true, bool withUserRef = true, bool withDepartemenRef = true)
        {
            var sql = "select * from pembelian where id_pembelian = @id_pembelian";

            var pembelian = dbConnection.Query<Pembelian>(sql, new { id_pembelian = id_pembelian }).SingleOrDefault();

            if (pembelian != null)
            {
                if (withDetails)
                    pembelian.PembelianDetails = PembelianDetail.GetListOfPembelian(dbConnection, pembelian);

                if (withSupplierRef)
                    pembelian.Supplier = Model.Supplier.GetSingle(dbConnection, pembelian.ID_Supplier);

                if (withUserRef)
                    pembelian.User = Model.User.GetSingle(dbConnection, pembelian.ID_User);

                if (withDepartemenRef)
                    pembelian.Departemen = Model.Departemen.GetSingle(dbConnection, pembelian.ID_Departemen);
            }

            return pembelian;
        }

        public static bool Delete(IDbTransaction t, Pembelian p)
        {
            var affected = 0;

            // Kembalikan stok item sesuai hasil pembelian
            var sql = 
                @"UPDATE stok_item SET stok = stok - (@jumlah * @konversi_jumlah) 
                WHERE id_item = @id_item AND id_departemen = @id_departemen";

            foreach (var pd in p.PembelianDetails)
            {
                affected += t.Connection.Execute(sql, new
                {
                    jumlah = pd.Jumlah,
                    konversi_jumlah = pd.SatuanItem.Konversi_Jumlah,
                    id_item = pd.ID_Item,
                    id_departemen = p.ID_Departemen
                }, t);
            }

            // Hapus tiap detail pembelian
            var sql2 = "DELETE FROM pembelian_detail WHERE id_pembelian = @id_pembelian";
            affected += t.Connection.Execute(sql2, p, t);

            // Hapus pembelian
            var sql3 = "DELETE FROM pembelian WHERE id_pembelian = @id_pembelian";
            affected += t.Connection.Execute(sql3, p, t);
            
            return (affected > 0);
        }

        public static string GenerateKodeTransaksi(IDbConnection dbConnection, Departemen departemen, IEnumerable<Model.Config> configs)
        {
            // mendapatkan format
            var formatKode = configs.First(s => s.Nama == "format_kode_pembelian").Nilai;
            // var formatKode = configIni.GetString("app", "format_kode_penjualan", "[COUNTER]/JL/[DEPARTEMEN]/[BLN][THN]");

            var digitCounter = int.Parse(configs.First(s => s.Nama == "digit_counter_pembelian").Nilai);
            // var digitCounter = configIni.GetInt32("app", "digit_counter_penjualan", 4);

            var resetCounter = configs.First(s => s.Nama == "reset_counter_pembelian").Nilai;
            //var resetCounter = configIni.GetString("app", "reset_counter_penjualan", "BULAN");

            // mendapatkan jumlah transaksi dalam periode reset
            var transactionCount = 0;

            if (resetCounter == "TAHUN")
            {
                var sql = @"
                    SELECT Count(*) AS count FROM pembelian
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
                    SELECT Count(*) AS count FROM pembelian
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
                    SELECT Count(*) AS count FROM pembelian
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
                dbConnection.Execute("UPDATE sequence SET next_value = 1 WHERE sequence_name = 'pembelian'");
            }

            string resultKodeTransaksi = "";

            // Generate dan Test kode
            do
            {
                // ambil sequence
                int next_value = dbConnection.ExecuteScalar<int>("SELECT next_value FROM sequence WHERE sequence_name = 'pembelian'");

                // increment sequence: di pindah ketika simpan transaksi
                dbConnection.Execute("UPDATE sequence SET next_value = next_value + increment WHERE sequence_name = 'pembelian'");

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
            } while (dbConnection.ExecuteScalar<int>("SELECT count(*) FROM pembelian WHERE kode_transaksi = '" + resultKodeTransaksi + "'") > 0);

            // kembalikan hasil
            return resultKodeTransaksi;
        }
    }

    public class PembelianDetail
    {
        public int ID_Pembelian_Detail { get; set; }
        public int ID_Pembelian { get; set; }
        public int ID_Item { get; set; }
        public int ID_Satuan { get; set; }

        public float Jumlah { get; set; }
        public int Harga_Beli { get; set; }
        public int Sub_Total { get; set; }

        // References Only
        public Model.Pembelian Pembelian { get; set; }
        public Model.Item Item { get; set; }
        public Model.SatuanItem SatuanItem { get; set; }

        // Untuk kebutuhan update & delete
        public float Old_Jumlah { get; set; }
        public int Old_ID_Satuan { get; set; }
        public bool ForDelete { get; set; }
        public bool Deleted { get; set; }

        public static List<Model.PembelianDetail> GetListOfPembelian(IDbConnection dbConnection, Pembelian p)
        {
            var sql = "select * from pembelian_detail where id_pembelian = @id_pembelian";

            var pembelianDetails = dbConnection.Query<Model.PembelianDetail>(sql, new { id_pembelian = p.ID_Pembelian }).ToList();

            // Mendapatkan SatuanItemViews
            foreach (var pd in pembelianDetails)
            {
                var sql2 = "select id_item, kode_item, nama_item from item where id_item = @id_item";
                pd.Item = dbConnection.Query<Model.Item>(sql2, new { id_item = pd.ID_Item }).First();
                pd.Item.SatuanItemViews = Model.Item.GetSatuanItemViews(dbConnection, pd.ID_Item);
                pd.SatuanItem = Model.SatuanItem.GetSingle(dbConnection, pd.ID_Item, pd.ID_Satuan);
            }

            return pembelianDetails;
        }
    }
}
