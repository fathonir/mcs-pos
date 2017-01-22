using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MCS_POS.Model
{
    public class KonsinyasiRetur
    {
        public int ID_Konsinyasi_Retur { get; set; }
        public int ID_Departemen { get; set; }
        public int ID_User { get; set; }
        public int ID_Supplier { get; set; }

        public string Kode_Transaksi { get; set; }
        public DateTime Waktu_Transaksi { get; set; }
        public int Jumlah_Item { get; set; }

        // reference object
        public Model.Departemen Departemen { get; set; }
        public Model.User User { get; set; }
        public Model.Supplier Supplier { get; set; }
        public List<Model.KonsinyasiReturDetail> KonsinyasiReturDetails { get; set; }

        // Row Info
        public Guid GUID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public static KonsinyasiRetur GetSingle(IDbConnection dbConnection, int id_konsinyasi_retur, bool withDetails = false, bool withSupplierRef = false, bool withUserRef = false, bool withDepartemenRef = false)
        {
            var sql = "select * from konsinyasi_retur where id_konsinyasi_retur = @id_konsinyasi_retur";

            var konsinyasiRetur = dbConnection.Query<KonsinyasiRetur>(sql, new { id_konsinyasi_retur = id_konsinyasi_retur }).SingleOrDefault();

            if (konsinyasiRetur != null)
            {
                if (withDetails)
                    konsinyasiRetur.KonsinyasiReturDetails = KonsinyasiReturDetail.GetListOfKonsinyasiRetur(dbConnection, konsinyasiRetur);

                if (withSupplierRef)
                    konsinyasiRetur.Supplier = Model.Supplier.GetSingle(dbConnection, konsinyasiRetur.ID_Supplier);

                if (withUserRef)
                    konsinyasiRetur.User = Model.User.GetSingle(dbConnection, konsinyasiRetur.ID_User);

                if (withDepartemenRef)
                    konsinyasiRetur.Departemen = Model.Departemen.GetSingle(dbConnection, konsinyasiRetur.ID_Departemen);
            }

            return konsinyasiRetur;
        }

        public static bool Add(IDbTransaction transaction, KonsinyasiRetur konsinyasiRetur)
        {
            var connection = transaction.Connection;

            var sql =
                @"INSERT INTO konsinyasi_retur
                (id_departemen, id_user, id_supplier, kode_transaksi, waktu_transaksi, jumlah_item, guid, created)
                VALUES
                (@id_departemen,@id_user,@id_supplier,@kode_transaksi,@waktu_transaksi,@jumlah_item,@guid,@created)";

            var affected = connection.Execute(sql, konsinyasiRetur, transaction);

            // Jika berhasil insert
            if (affected > 0)
            {
                // Ambil ID_Konsinyasi_Retur yg berhasil terinsert
                konsinyasiRetur.ID_Konsinyasi_Retur = connection.ExecuteScalar<int>("SELECT last_insert_id()", null, transaction);

                // Tambahkan detail-detail ke database
                foreach (var konsReturDetail in konsinyasiRetur.KonsinyasiReturDetails)
                {
                    // Set FK ID_Konsinyasi_Retur
                    konsReturDetail.ID_Konsinyasi_Retur = konsinyasiRetur.ID_Konsinyasi_Retur;

                    // SQL insert detail konsinyasi retur
                    var sql2 =
                        @"INSERT INTO konsinyasi_retur_detail
                        (id_konsinyasi_retur, id_item, id_satuan, jumlah)
                        VALUES
                        (@id_konsinyasi_retur,@id_item,@id_satuan,@jumlah)";

                    // Eksekusi Insert detail konsinyasi retur
                    affected += connection.Execute(sql2, konsReturDetail, transaction);

                    // SQL Update stok
                    var sql3 =
                        @"UPDATE stok_item s 
                            JOIN satuan_item si ON si.id_item = s.id_item
                        SET s.stok = s.stok - (@jumlah * si.konversi_jumlah)
                        WHERE 
	                        s.id_departemen = @id_departemen AND
                            s.id_item = @id_item AND
                            si.id_satuan = @id_satuan";

                    // Eksekusi update stok
                    affected += connection.Execute(sql3, new {
                        jumlah = konsReturDetail.Jumlah,
                        id_departemen = konsinyasiRetur.ID_Departemen,
                        id_item = konsReturDetail.ID_Item,
                        id_satuan = konsReturDetail.ID_Satuan
                    }, transaction);


                    // ============================================================
                    // FIFO - Section
                    // Update jumlah retur pada transaksi retur masuk yg ada barang
                    // ============================================================

                    // Ambil detail konsinyasi masuk di item yg sama
                    var konsinyasiDetails = connection.Query<KonsinyasiDetail>(
                        @"SELECT kd.* FROM konsinyasi_detail kd
                        JOIN konsinyasi k ON k.id_konsinyasi = kd.id_konsinyasi
                        WHERE 
                            jumlah - jumlah_keluar - jumlah_retur > 0 AND
                            k.id_departemen = @id_departemen AND 
                            kd.id_item = @id_item
                        ORDER BY k.waktu_transaksi ASC",
                        new {
                            id_departemen = konsinyasiRetur.ID_Departemen,
                            id_item = konsReturDetail.ID_Item
                        }).AsList();

                    // Diproses hanya jika data transaksi konsinyasi ditemukan
                    if (konsinyasiDetails.Count > 0)
                    {
                        // ambil satuan konsinyasi retur
                        konsReturDetail.SatuanItem = SatuanItem.GetSingle(connection, konsReturDetail.ID_Item, konsReturDetail.ID_Satuan);
                        var totalRetur = konsReturDetail.Jumlah * konsReturDetail.SatuanItem.Konversi_Jumlah;

                        // tiap transaksi konsinyasi di cek
                        foreach (var konsinyasiDetail in konsinyasiDetails)
                        {
                            // ambil satuan konsinyasi
                            konsinyasiDetail.SatuanItem = SatuanItem.GetSingle(connection, konsinyasiDetail.ID_Item, konsinyasiDetail.ID_Satuan);

                            // hitung sisa yg bisa dikembalikan
                            var sisa = ((float)konsinyasiDetail.Jumlah - konsinyasiDetail.Jumlah_Retur - konsinyasiDetail.Jumlah_Keluar) * konsinyasiDetail.SatuanItem.Konversi_Jumlah;

                            // jika pengurangan lebih dari sisa
                            if (sisa - totalRetur < 0)
                            {
                                konsinyasiDetail.Jumlah_Retur = konsinyasiDetail.Jumlah_Retur + (sisa / konsinyasiDetail.SatuanItem.Konversi_Jumlah);
                                totalRetur = totalRetur - sisa;

                                affected += connection.Execute(
                                    "UPDATE konsinyasi_detail SET jumlah_retur = @jumlah_retur WHERE id_konsinyasi_detail = @id_konsinyasi_detail",
                                    konsinyasiDetail, transaction);
                            }
                            else if (sisa - totalRetur >= 0)
                            {
                                konsinyasiDetail.Jumlah_Retur = konsinyasiDetail.Jumlah_Retur + (totalRetur / konsinyasiDetail.SatuanItem.Konversi_Jumlah);

                                affected += connection.Execute(
                                    "UPDATE konsinyasi_detail SET jumlah_retur = @jumlah_retur WHERE id_konsinyasi_detail = @id_konsinyasi_detail",
                                    konsinyasiDetail, transaction);

                                // Akhiri looping setelah sisa yg tak habis dikurang retur
                                break;
                            }
                        }
                    }

                    /**
                    if (konsinyasiDetail != null)
                    {
                        // ambil satuan konsinyasi
                        konsinyasiDetail.SatuanItem = SatuanItem.GetSingle(connection, konsinyasiDetail.ID_Item, konsinyasiDetail.ID_Satuan);

                        // ambil satuan konsinyasi retur
                        konsReturDetail.SatuanItem = SatuanItem.GetSingle(connection, konsReturDetail.ID_Item, konsReturDetail.ID_Satuan);

                        // Hitung jumlah_retur target
                        konsinyasiDetail.Jumlah_Retur =
                            (konsReturDetail.Jumlah * konsReturDetail.SatuanItem.Konversi_Jumlah) /
                            (konsinyasiDetail.SatuanItem.Konversi_Jumlah);

                        // Update konsinyasi detail
                        var sql5 = "UPDATE konsinyasi_detail SET jumlah_retur = @jumlah_retur WHERE id_konsinyasi_detail = @id_konsinyasi_detail";
                        affected += connection.Execute(sql5, konsinyasiDetail, transaction);
                    }
                    */
                }

                // Tambahkan increment konsinyasi retur
                affected += transaction.Connection.Execute("UPDATE sequence SET next_value = next_value + increment WHERE sequence_name = 'konsinyasi_retur'");
            }

            return (affected > 0);
        }

        public static string GenerateKode(IDbConnection dbConnection, Model.Departemen departemen, List<Config> configs)
        {
            // mendapatkan format, default = [COUNTER]/RKI/[DEPARTEMEN]/[BLN][THN]
            var formatKode = configs.First(s => s.Nama == Model.Config.FORMAT_KODE_KONSINYASI_RETUR).Nilai;

            // digit counter, default = 4
            var digitCounter = int.Parse(configs.First(s => s.Nama == Model.Config.DIGIT_COUNTER_KONSINYASI_RETUR).Nilai);

            // reset perulangan counter, default = BULAN
            var resetCounter = configs.First(s => s.Nama == Model.Config.RESET_COUNTER_KONSINYASI_RETUR).Nilai;

            // mendapatkan jumlah transaksi dalam periode reset
            var transactionCount = 0;


            if (resetCounter == "TAHUN")
            {
                var sql = @"
                    SELECT Count(*) AS count FROM konsinyasi_retur
                    WHERE id_departemen = @id_departemen AND Year(waktu_transaksi) = @tahun";

                transactionCount = dbConnection.ExecuteScalar<int>(sql, new {
                    id_departemen = departemen.ID_Departemen,
                    tahun = DateTime.Now.Year
                });
            }

            if (resetCounter == "BULAN")
            {
                var sql = @"
                    SELECT Count(*) AS count FROM konsinyasi_retur
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
                    SELECT Count(*) AS count FROM konsinyasi_retur
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
                dbConnection.Execute("UPDATE sequence SET next_value = 1 WHERE sequence_name = 'konsinyasi_retur'");
            }

            string resultKodeTransaksi = "";

            // Generate dan Test kode
            do
            {
                // ambil sequence
                int next_value = dbConnection.ExecuteScalar<int>("SELECT next_value FROM sequence WHERE sequence_name = 'konsinyasi_retur'");

                // increment sequence : di pindah ketika simpan Transaksi Baru
                // dbConnection.Execute("UPDATE sequence SET next_value = next_value + increment WHERE sequence_name = 'konsinyasi'");

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
            } while (dbConnection.ExecuteScalar<int>("SELECT count(*) FROM konsinyasi_retur WHERE kode_transaksi = '" + resultKodeTransaksi + "'") > 0);

            // kembalikan hasil
            return resultKodeTransaksi;
        }

        public static bool Update(IDbTransaction transaction, KonsinyasiRetur konsinyasiRetur)
        {
            var connection = transaction.Connection;

            var sql =
                @"UPDATE konsinyasi_retur SET
                    waktu_transaksi = @waktu_transaksi,
                    id_supplier = @id_supplier,
                    jumlah_item = @jumlah_item,
                    id_user = @id_user,
                    modified = @modified
                WHERE id_konsinyasi_retur = @id_konsinyasi_retur";

            var affected = connection.Execute(sql, konsinyasiRetur, transaction);

            // =================================================
            // Urutan proses data row : DELETE > UPDATE > INSERT
            // =================================================

            if (affected > 0)
            {
                foreach (var konsReturDetail in konsinyasiRetur.KonsinyasiReturDetails)
                {
                    if (konsReturDetail.ForDelete)
                    {
                        // ==============================================================================
                        // Mengembalikan stok yg sudah pernah dikurangi akibat konsinyasi retur
                        // STOK = STOK + (JUMLAH * KONVERSI)
                        // ==============================================================================
                        sql =
                            @"UPDATE stok_item SET
                                stok = stok + (
                                    SELECT kd.jumlah * si.konversi_jumlah FROM konsinyasi_retur_detail kd
                                    JOIN satuan_item si ON si.id_item = kd.id_item AND si.id_satuan = kd.id_satuan
                                    WHERE kd.id_konsinyasi_retur_detail = @id_konsinyasi_retur_detail)
                            WHERE id_item = @id_item AND id_departemen = @id_departemen";
                        affected += connection.Execute(sql, new {
                            id_konsinyasi_detail = konsReturDetail.ID_Konsinyasi_Retur_Detail,
                            id_item = konsReturDetail.ID_Item,
                            id_departemen = konsinyasiRetur.ID_Departemen
                        }, transaction);

                        // Hapus Item
                        sql = "DELETE FROM konsinyasi_retur_detail WHERE id_konsinyasi_retur_detail = @id_konsinyasi_retur_detail";
                        var deleted = connection.Execute(sql, konsReturDetail, transaction);
                        if (deleted > 0) { konsReturDetail.Deleted = true; }

                        // tambahkan affected rows-nya
                        affected += deleted;

                        // next loop
                        continue;
                    }

                    // Item For Update
                    if (konsReturDetail.ID_Konsinyasi_Retur_Detail != -1)
                    {
                        // ==============================================================================
                        // Proses Update
                        // 1. Mengembalikan stok yg sudah pernah dikurangi akibat konsinyasi retur
                        // 2. Update info detail konsinyasi retur
                        // 3. Kurangi stok sesuai hasil konsinyasi retur yg baru
                        // ==============================================================================
                        sql =
                            @"UPDATE stok_item SET
                                stok = stok + (
                                    SELECT kd.jumlah * si.konversi_jumlah FROM konsinyasi_retur_detail kd
                                    JOIN satuan_item si ON si.id_item = kd.id_item AND si.id_satuan = kd.id_satuan
                                    WHERE kd.id_konsinyasi_retur_detail = @id_konsinyasi_retur_detail)
                            WHERE id_item = @id_item AND id_departemen = @id_departemen";
                        affected += connection.Execute(sql, new {
                            id_konsinyasi_retur_detail = konsReturDetail.ID_Konsinyasi_Retur_Detail,
                            id_item = konsReturDetail.ID_Item,
                            id_departemen = konsinyasiRetur.ID_Departemen
                        }, transaction);


                        sql =
                            @"UPDATE konsinyasi_retur_detail SET
                                id_satuan = @id_satuan, 
                                jumlah = @jumlah
                            WHERE id_konsinyasi_retur_detail = @id_konsinyasi_retur_detail";
                        affected += connection.Execute(sql, konsReturDetail, transaction);

                        sql =
                            @"UPDATE stok_item SET
                                stok = stok - (
                                    SELECT kd.jumlah * si.konversi_jumlah FROM konsinyasi_retur_detail kd
                                    JOIN satuan_item si ON si.id_item = kd.id_item AND si.id_satuan = kd.id_satuan
                                    WHERE kd.id_konsinyasi_retur_detail = @id_konsinyasi_retur_detail)
                            WHERE id_item = @id_item AND id_departemen = @id_departemen";
                        affected += connection.Execute(sql, new {
                            id_konsinyasi_retur_detail = konsReturDetail.ID_Konsinyasi_Retur_Detail,
                            id_item = konsReturDetail.ID_Item,
                            id_departemen = konsinyasiRetur.ID_Departemen
                        }, transaction);

                        // next loop
                        continue;
                    }

                    // Item For Insert
                    if (konsReturDetail.ID_Konsinyasi_Retur_Detail == -1)
                    {
                        // Insert konsinyasi detail
                        sql =
                           @"INSERT INTO konsinyasi_retur_detail
                           (id_konsinyasi_retur, id_item, id_satuan, jumlah)
                           VALUES
                           (@id_konsinyasi_retur,@id_item,@id_satuan,@jumlah)";

                        affected += connection.Execute(sql, konsReturDetail, transaction);

                        // Ambil PK id_konsinyasi_detail
                        konsReturDetail.ID_Konsinyasi_Retur_Detail = connection.ExecuteScalar<int>("SELECT last_insert_id()", null, transaction);

                        // update stok
                        sql =
                            @"UPDATE stok_item s 
                                JOIN satuan_item si ON si.id_item = s.id_item
                            SET s.stok = s.stok - (@jumlah * si.konversi_jumlah)
                            WHERE 
	                            s.id_departemen = @id_departemen AND
                                s.id_item = @id_item AND
                                si.id_satuan = @id_satuan";

                        affected += connection.Execute(sql, new {
                            jumlah = konsReturDetail.Jumlah,
                            id_departemen = konsinyasiRetur.ID_Departemen,
                            id_item = konsReturDetail.ID_Item,
                            id_satuan = konsReturDetail.ID_Satuan
                        }, transaction);
                    }
                }
            }

            return (affected > 0);
        }

        public static bool Delete(System.Data.IDbTransaction transaction, KonsinyasiRetur konsinyasiRetur)
        {
            var connection = transaction.Connection;
            var affected = 0;

            foreach (var konsReturDetail in konsinyasiRetur.KonsinyasiReturDetails)
            {
                // Kembalikan stok item sesuai hasil konsinyasi retur
                affected += connection.Execute(
                    @"UPDATE stok_item SET stok = stok + (@jumlah * @konversi_jumlah) 
                    WHERE id_item = @id_item AND id_departemen = @id_departemen",
                    new {
                        jumlah = konsReturDetail.Jumlah,
                        konversi_jumlah = konsReturDetail.SatuanItem.Konversi_Jumlah,
                        id_item = konsReturDetail.ID_Item,
                        id_departemen = konsinyasiRetur.ID_Departemen
                    }, transaction);

                // --------------------------------------------------------------
                // FIFO Section
                // Mengembalikan jumlah retur pada konsinyasi yg
                // sudah ditambahkan di transaki detail konsinyasi
                // --------------------------------------------------------------
                var totalRetur = konsReturDetail.Jumlah * konsReturDetail.SatuanItem.Konversi_Jumlah;
                var nextKonsinyasiDetail = false;

                do
                {
                    // Ambil transaksi konsinyasi masuk terakhir
                    var konsinyasiDetail = connection.Query<KonsinyasiDetail>(
                        @"SELECT kd.* FROM konsinyasi_detail kd
                        JOIN konsinyasi k ON k.id_konsinyasi = kd.id_konsinyasi
                        WHERE k.id_departemen = @id_departemen AND kd.id_item = @id_item AND jumlah_retur > 0
                        ORDER BY k.waktu_transaksi DESC LIMIT 1",
                        new {
                            id_departemen = konsinyasiRetur.ID_Departemen,
                            id_item = konsReturDetail.ID_Item
                        }).SingleOrDefault();

                    // Proses jika hanya ada data konsinyasi ada nilai retur
                    if (konsinyasiDetail != null)
                    {
                        konsinyasiDetail.SatuanItem = SatuanItem.GetSingle(connection, konsinyasiDetail.ID_Item, konsinyasiDetail.ID_Satuan);
                        var retur = konsinyasiDetail.Jumlah_Retur * konsinyasiDetail.SatuanItem.Konversi_Jumlah;

                        if (retur - totalRetur < 0)
                        {
                            konsinyasiDetail.Jumlah_Retur = 0;
                            totalRetur = totalRetur - retur;

                            affected += connection.Execute(
                                @"UPDATE konsinyasi_detail SET jumlah_retur = @jumlah_retur WHERE id_konsinyasi_detail = @id_konsinyasi_detail",
                                konsinyasiDetail, transaction);

                            nextKonsinyasiDetail = true;
                        }
                        else if (retur - totalRetur >= 0)
                        {
                            konsinyasiDetail.Jumlah_Retur = konsinyasiDetail.Jumlah_Retur - (totalRetur / konsinyasiDetail.SatuanItem.Konversi_Jumlah);
                            totalRetur = 0;

                            affected += connection.Execute(
                                @"UPDATE konsinyasi_detail SET jumlah_retur = @jumlah_retur WHERE id_konsinyasi_detail = @id_konsinyasi_detail",
                                konsinyasiDetail, transaction);
                        }
                    }
                    else
                    {
                        break;
                    }

                } while (nextKonsinyasiDetail);
                
            }

            // Hapus tiap detail konsinyasi
            var sql2 = "DELETE FROM konsinyasi_retur_detail WHERE id_konsinyasi_retur = @id_konsinyasi_retur";
            affected += connection.Execute(sql2, konsinyasiRetur, transaction);

            // Hapus konsinyasi
            var sql3 = "DELETE FROM konsinyasi_retur WHERE id_konsinyasi_retur = @id_konsinyasi_retur";
            affected += connection.Execute(sql3, konsinyasiRetur, transaction);

            return (affected > 0);
        }
    }

    public class KonsinyasiReturDetail
    {
        public int ID_Konsinyasi_Retur_Detail { get; set; }
        public int ID_Konsinyasi_Retur { get; set; }
        public int ID_Item { get; set; }
        public int ID_Satuan { get; set; }

        public int Jumlah { get; set; }
        public int Harga_Beli { get; set; }
        public int Sub_Total { get; set; }

        public int Old_Jumlah { get; set; }
        public int Old_ID_Satuan { get; set; }

        // reference object
        public Model.KonsinyasiRetur KonsinyasiRetur { get; set; }
        public Model.Item Item { get; set; }
        public Model.Satuan Satuan { get; set; }
        public Model.SatuanItem SatuanItem { get; set; }

        // Status object
        public bool ForDelete { get; set; }
        public bool Deleted { get; set; }

        internal static List<KonsinyasiReturDetail> GetListOfKonsinyasiRetur(IDbConnection dbConnection, Model.KonsinyasiRetur konsinyasiRetur)
        {
            var sql = "select * from konsinyasi_retur_detail where id_konsinyasi_retur = @id_konsinyasi_retur";

            var konsReturDetails = dbConnection.Query<Model.KonsinyasiReturDetail>(sql, konsinyasiRetur).ToList();

            // Mendapatkan SatuanItemViews
            foreach (var konsReturDetail in konsReturDetails)
            {
                var sql2 = "select id_item, kode_item, nama_item from item where id_item = @id_item";
                konsReturDetail.Item = dbConnection.Query<Model.Item>(sql2, konsReturDetail).First();
                konsReturDetail.Item.SatuanItemViews = Model.Item.GetSatuanItemViews(dbConnection, konsReturDetail.ID_Item);
                konsReturDetail.SatuanItem = Model.SatuanItem.GetSingle(dbConnection, konsReturDetail.ID_Item, konsReturDetail.ID_Satuan);
            }

            return konsReturDetails;
        }
    }
}
