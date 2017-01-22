using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;

namespace MCS_POS.Model
{
    public class Transfer
    {
        public int ID_Transfer { get; set; }
        public int ID_Departemen { get; set; }
        public int ID_Departemen_Asal { get; set; }
        public int ID_Departemen_Tujuan { get; set; }
        public int ID_User { get; set; }

        // Reference
        public Departemen Departemen { get; set; }
        public Departemen DepartemenAsal { get; set; }
        public Departemen DepartemenTujuan { get; set; }
        public User User { get; set; }
        public List<TransferDetail> TransferDetails { get; set; }

        public string Kode_Transaksi { get; set; }
        public DateTime Waktu_Transaksi { get; set; }
        public string Keterangan { get; set; }
        public int Jumlah_Item { get; set; }

        public Guid GUID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public static bool Add(IDbTransaction t, Transfer tr)
        {
            const string sql = 
                @"INSERT INTO transfer (id_departemen, id_departemen_asal, id_departemen_tujuan, id_user, kode_transaksi, waktu_transaksi, keterangan, jumlah_item, guid, created)
                VALUES (@id_departemen, @id_departemen_asal, @id_departemen_tujuan, @id_user, @kode_transaksi, @waktu_transaksi, @keterangan, @jumlah_item, @guid, @created)";

            var affected = t.Connection.Execute(sql, tr, t);

            if (affected > 0)
            {
                // Ambil PK
                tr.ID_Transfer = t.Connection.ExecuteScalar<int>("SELECT last_insert_id()");

                // Tambahkan detail-detail ke database
                foreach (var td in tr.TransferDetails)
                {
                    // Transfer foreign key
                    td.ID_Transfer = tr.ID_Transfer;

                    // sql insert detail transfer
                    const string sql2 =
                        @"INSERT INTO transfer_detail (id_transfer, id_item, jumlah, id_satuan, harga)
                        VALUES (@id_transfer, @id_item, @jumlah, @id_satuan, @harga)";

                    // Execute
                    affected += t.Connection.Execute(sql2, td, t);

                    // Ambil PK
                    td.ID_Transfer_Detail = t.Connection.ExecuteScalar<int>("SELECT last_insert_id()");

                    // sql update stok item tujuan
                    const string sql3 =
                        @"UPDATE stok_item s
                            JOIN satuan_item si ON si.id_item = s.id_item
                        SET s.stok = s.stok + (@jumlah * si.konversi_jumlah)
                        WHERE 
                            s.id_departemen = @id_departemen_ke AND
                            s.id_item = @id_item AND
                            si.id_satuan = @id_satuan";
                    
                    // Execute
                    affected += t.Connection.Execute(sql3, new { 
                        jumlah = td.Jumlah,
                        id_departemen_ke = tr.ID_Departemen_Tujuan,
                        id_item = td.ID_Item,
                        id_satuan = td.ID_Satuan
                    }, t);

                    // sql update stok item sumber
                    const string sql4 =
                        @"UPDATE stok_item s
                            JOIN satuan_item si ON si.id_item = s.id_item
                        SET s.stok = s.stok + (@jumlah * si.konversi_jumlah)
                        WHERE 
                            s.id_departemen = @id_departemen_dari AND
                            s.id_item = @id_item AND
                            si.id_satuan = @id_satuan";

                    // execute
                    affected += t.Connection.Execute(sql4, new
                    {
                        jumlah = td.Jumlah,
                        id_departemen_dari = tr.ID_Departemen_Asal,
                        id_item = td.ID_Item,
                        id_satuan = td.ID_Satuan
                    }, t);
                }

                // Tambahkan increment transfer
                affected += t.Connection.Execute("UPDATE sequence SET next_value = next_value + increment WHERE sequence_name = 'transfer'");
            }

            return false;
        }

        public static bool Update(IDbTransaction t, Transfer transfer)
        {
            // Update informasi transfer
            var sql = @"
                UPDATE transfer SET
                    waktu_transaksi = @waktu_transaksi,
                    jumlah_item     = @jumlah_item,
                    modified        = @modified
                WHERE id_transfer = @id_transfer";

            var affected = t.Connection.Execute(sql, transfer, t);

            // =================================================
            // Urutan proses data row : DELETE > UPDATE > INSERT
            // =================================================

            // Update detail-detail
            foreach (var transferDetail in transfer.TransferDetails)
            {
                // sql item dihapus
                if (transferDetail.ForDelete)
                {
                    // Hapus Item
                    sql = "DELETE FROM transfer_detail WHERE id_transfer_detail = @id_transfer_detail";
                    var deleted = t.Connection.Execute(sql, transferDetail, t);
                    if (deleted > 0) { transferDetail.Deleted = true; }

                    // tambahkan affected rows-nya
                    affected += deleted;

                    // ==============================================================================
                    // Rumus delete stok dept asal
                    // STOK = STOK + (JUMLAH * KONVERSI)
                    // ==============================================================================
                    sql = @"
                        UPDATE stok_item stok
                        JOIN transfer_detail td ON td.id_item = stok.id_item 
                        JOIN satuan_item si on si.id_item = td.id_item AND si.id_satuan = td.id_satuan
                        SET stok.stok = stok.stok + (td.jumlah * si.konversi_jumlah)
                        WHERE td.id_item = @id_item AND stok.id_departemen = @id_departemen_asal";
                    affected += t.Connection.Execute(sql, new { 
                        id_item = transferDetail.ID_Item,
                        id_departemen_asal = transfer.ID_Departemen_Asal
                    }, t);


                    // ==============================================================================
                    // Rumus delete stok dept tujuan
                    // STOK = STOK - (JUMLAH * KONVERSI)
                    // ==============================================================================
                    sql = @"
                        UPDATE stok_item stok
                        JOIN transfer_detail td ON td.id_item = stok.id_item 
                        JOIN satuan_item si on si.id_item = td.id_item AND si.id_satuan = td.id_satuan
                        SET stok.stok = stok.stok - (td.jumlah * si.konversi_jumlah)
                        WHERE td.id_item = @id_item AND stok.id_departemen = @id_departemen_tujuan";
                    affected += t.Connection.Execute(sql, new
                    {
                        id_item = transferDetail.ID_Item,
                        id_departemen_tujuan = transfer.ID_Departemen_Tujuan
                    }, t);


                    // lanjutkan next item
                    continue; 
                }

                // sql item update (bukan di delete & bukan PK=-1)
                if (!transferDetail.ForDelete && transferDetail.ID_Transfer_Detail != -1)
                {
                    // ==============================================================================
                    // Rumus update stok dept asal
                    // STOK = STOK + (JUMLAH_LAMA * KONVERSI_LAMA) - (JUMLAH_BARU * KONVERSI_BARU)
                    // ==============================================================================
                    var stokDeptAsal = t.Connection.ExecuteScalar<int>(
                        "SELECT stok FROM stok_item WHERE id_item = @id_item AND id_departemen = @id_departemen_asal", new { 
                            id_item = transferDetail.ID_Item,
                            id_departemen_asal = transfer.ID_Departemen_Asal
                        });

                    var jumlahLama = t.Connection.ExecuteScalar<int>(
                        @"SELECT jumlah*konversi_jumlah FROM transfer_detail td
                        JOIN satuan_item si ON si.id_item = td.id_item AND si.id_satuan = td.id_satuan
                        WHERE td.id_transfer_detail = @id_transfer_detail", transferDetail);
                    var jumlahBaru = t.Connection.ExecuteScalar<int>(
                        @"SELECT @jumlah*konversi_jumlah FROM satuan_item si
                        WHERE id_item = @id_item AND id_satuan = @id_satuan", transferDetail);

                    // Update stok dept asal
                    sql = "UPDATE stok_item SET stok = @stok WHERE id_item = @id_item AND id_departemen = @id_departemen_asal";
                    affected += t.Connection.Execute(sql, new { 
                        stok = stokDeptAsal + jumlahLama - jumlahBaru,
                        id_item = transferDetail.ID_Item,
                        id_departemen_asal = transfer.ID_Departemen_Asal
                    },t);


                    // ==============================================================================
                    // Rumus update stok dept tujuan
                    // STOK = STOK - (JUMLAH_LAMA * KONVERSI_LAMA) + (JUMLAH_BARU * KONVERSI_BARU)
                    // ==============================================================================
                    var stokDeptTujuan = t.Connection.ExecuteScalar<int>(
                        "SELECT stok FROM stok_item WHERE id_item = @id_item AND id_departemen = @id_departemen_tujuan", new
                        {
                            id_item = transferDetail.ID_Item,
                            id_departemen_tujuan = transfer.ID_Departemen_Tujuan
                        });

                    // Update stok dept tujuan
                    sql = "UPDATE stok_item SET stok = @stok WHERE id_item = @id_item AND id_departemen = @id_departemen_tujuan";
                    affected += t.Connection.Execute(sql, new
                    {
                        stok = stokDeptTujuan - jumlahLama + jumlahBaru,
                        id_item = transferDetail.ID_Item,
                        id_departemen_tujuan = transfer.ID_Departemen_Tujuan
                    }, t);


                    // Update transfer_detail
                    sql = @"
                        UPDATE transfer_detail SET 
                            jumlah = @jumlah, 
                            id_satuan = @id_satuan,
                            harga = @harga
                        WHERE id_transfer_detail = @id_transfer_detail";
                    affected += t.Connection.Execute(sql, transferDetail, t);

                    // lanjutkan next item
                    continue;
                }

                // sql item insert, PK baru
                if (transferDetail.ID_Transfer_Detail == -1)
                {
                    // sql insert detail transfer
                    sql =
                        @"INSERT INTO transfer_detail (id_transfer, id_item, jumlah, id_satuan, harga)
                        VALUES (@id_transfer, @id_item, @jumlah, @id_satuan, @harga)";

                    // Execute
                    affected += t.Connection.Execute(sql, transferDetail, t);

                    // Ambil PK
                    transferDetail.ID_Transfer_Detail = t.Connection.ExecuteScalar<int>("SELECT last_insert_id()");

                    // sql update stok item tujuan
                    sql =
                        @"UPDATE stok_item s
                        JOIN satuan_item si ON si.id_item = s.id_item
                        SET s.stok = s.stok + (@jumlah * si.konversi_jumlah)
                        WHERE 
                            s.id_departemen = @id_departemen_tujuan AND
                            s.id_item = @id_item AND
                            si.id_satuan = @id_satuan";

                    // Execute
                    affected += t.Connection.Execute(sql, new
                    {
                        jumlah = transferDetail.Jumlah,
                        id_departemen_tujuan = transfer.ID_Departemen_Tujuan,
                        id_item = transferDetail.ID_Item,
                        id_satuan = transferDetail.ID_Satuan
                    }, t);

                    // sql update stok item sumber
                    sql =
                        @"UPDATE stok_item s
                        JOIN satuan_item si ON si.id_item = s.id_item
                        SET s.stok = s.stok + (@jumlah * si.konversi_jumlah)
                        WHERE 
                            s.id_departemen = @id_departemen_asal AND
                            s.id_item = @id_item AND
                            si.id_satuan = @id_satuan";

                    // execute
                    affected += t.Connection.Execute(sql, new
                    {
                        jumlah = transferDetail.Jumlah,
                        id_departemen_asal = transfer.ID_Departemen_Asal,
                        id_item = transferDetail.ID_Item,
                        id_satuan = transferDetail.ID_Satuan
                    }, t);

                    // lanjutkan next item
                    continue;
                }
            }

            return (affected > 0);
        }

        public static string GenerateKode(IDbConnection dbConnection, Departemen departemen, IEnumerable<Model.Config> configs)
        {
            // mendapatkan format
            var formatKode = configs.First(s => s.Nama == "format_kode_transfer").Nilai;
            
            // digit counter
            var digitCounter = int.Parse(configs.First(s => s.Nama == "digit_counter_transfer").Nilai);

            // periode reset counter
            var resetCounter = configs.First(s => s.Nama == "reset_counter_transfer").Nilai;

            // jumlah transaksi, default = 0
            var transactionCount = 0;

            if (resetCounter == "TAHUN")
            {
                var sql = 
                    @"SELECT Count(*) FROM transfer 
                    WHERE id_departemen = @id_departemen AND 
                    Year(waktu_transaksi) = @tahun";

                transactionCount = dbConnection.ExecuteScalar<int>(sql, new { 
                    id_departemen = departemen.ID_Departemen,
                    tahun = DateTime.Now.Year
                });
            }

            if (resetCounter == "BULAN")
            {
                var sql = @"SELECT Count(*) FROM transfer 
                    WHERE id_departemen = @id_departemen AND 
                    Year(waktu_transaksi) = @tahun AND 
                    Month(waktu_transaksi) = @bulan";

                transactionCount = dbConnection.ExecuteScalar<int>(sql, new
                {
                    id_departemen = departemen.ID_Departemen,
                    tahun = DateTime.Now.Year,
                    bulan = DateTime.Now.Month
                });
            }

            if (resetCounter == "HARI")
            {
                var sql = @"SELECT Count(*) FROM transfer 
                    WHERE id_departemen = @id_departemen AND 
                    Year(waktu_transaksi) = @tahun AND 
                    Month(waktu_transaksi) = @bulan AND
                    Day(waktu_transaksi) = @tanggal";

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
                dbConnection.Execute("UPDATE sequence SET next_value = 1 WHERE sequence_name = 'transfer'");
            }

            string resultKodeTransaksi = "";

            do 
            {
                // ambil sequence
                int next_value = dbConnection.ExecuteScalar<int>("SELECT next_value FROM sequence WHERE sequence_name = 'transfer'");

                // increment sequence : dipindah ketika simpan transaksi
                //dbConnection.Execute("UPDATE sequence SET next_value = next_value + increment WHERE sequence_name = 'transfer'");

                // ambil kode departemen
                string kode_departemen = dbConnection.ExecuteScalar<string>("SELECT kode_departemen FROM departemen WHERE id_departemen = " + departemen.ID_Departemen);

                // kembalikan hasil sesuai format kode,
                // ditambahi [TGL], menjadi bug ketika format harian
                resultKodeTransaksi = formatKode
                    .Replace("[COUNTER]", next_value.ToString().PadLeft(digitCounter, '0'))
                    .Replace("[DEPARTEMEN]", kode_departemen)
                    .Replace("[TGL]", DateTime.Now.ToString("dd"))
                    .Replace("[BLN]", DateTime.Now.ToString("MM"))
                    .Replace("[THN]", DateTime.Now.ToString("yy"));

            } while (dbConnection.ExecuteScalar<int>("SELECT count(*) FROM transfer WHERE kode_transaksi = '" + resultKodeTransaksi + "'") > 0);

            return resultKodeTransaksi;
        }

        public static Transfer GetSingle(IDbConnection dbConnection, int id_transfer, bool withDetails = false, bool withUserRef = false)
        {
            const string sql = "select * from transfer where id_transfer = @id_transfer";

            var transfer = dbConnection.Query<Transfer>(sql, new { id_transfer = id_transfer }).SingleOrDefault();

            if (transfer != null)
            {
                if (withDetails)
                    Model.TransferDetail.GetListOfTransfer(dbConnection, transfer);

                if (withUserRef)
                    transfer.User = Model.User.GetSingle(dbConnection, transfer.ID_User);
            }

            return transfer;
        }

        public static bool Delete(IDbTransaction transaction, Transfer transfer)
        {
            var connection = transaction.Connection;
            var affected = 0;

            foreach (var transferDetail in transfer.TransferDetails)
            {
                // Kembalikan stok item departemen asal sesuai hasil transfer
                affected += connection.Execute(
                    @"UPDATE stok_item SET stok = stok + (@jumlah * @konversi_jumlah) 
                    WHERE id_item = @id_item AND id_departemen = @id_departemen",
                    new {
                        jumlah = transferDetail.Jumlah,
                        konversi_jumlah = transferDetail.SatuanItem.Konversi_Jumlah,
                        id_item = transferDetail.ID_Item,
                        id_departemen = transfer.ID_Departemen_Asal
                    }, transaction);

                // Kembalikan stok item departemen tujuan sesuai hasil transfer
                affected += connection.Execute(
                    @"UPDATE stok_item SET stok = stok - (@jumlah * @konversi_jumlah) 
                    WHERE id_item = @id_item AND id_departemen = @id_departemen",
                    new {
                        jumlah = transferDetail.Jumlah,
                        konversi_jumlah = transferDetail.SatuanItem.Konversi_Jumlah,
                        id_item = transferDetail.ID_Item,
                        id_departemen = transfer.ID_Departemen_Tujuan
                    }, transaction);
            }

            // Hapus transfer detail
            affected += connection.Execute(
                "DELETE FROM transfer_detail WHERE id_transfer = @id_transfer", 
                transfer, transaction);

            // Hapus transfer header
            affected += connection.Execute(
                "DELETE FROM transfer WHERE id_transfer = @id_transfer",
                transfer, transaction);

            return (affected > 0);
        }
    }

    public class TransferDetail
    {
        public int ID_Transfer_Detail { get; set; }
        public int ID_Transfer { get; set; }
        public int ID_Item { get; set; }

        // Reference
        public Transfer Transfer { get; set; }
        public Item Item { get; set; }
        public SatuanItem SatuanItem { get; set; }

        public int Jumlah { get; set; }
        public int ID_Satuan { get; set; }
        public int Harga { get; set; }

        // Untuk kebutuhan update & delete
        public int Old_Jumlah { get; set; }
        public int Old_ID_Satuan { get; set; }
        public bool ForDelete { get; set; }
        public bool Deleted { get; set; }

        public static List<TransferDetail> GetListOfTransfer(IDbConnection dbConnection, Transfer t)
        {
            const string sql = "select * from transfer_detail where id_transfer = @id_transfer";

            t.TransferDetails = dbConnection.Query<Model.TransferDetail>(sql, new { id_transfer = t.ID_Transfer }).ToList();

            // Mendapatkan Item, SatuanItemViews dan SatuanItem
            foreach (var td in t.TransferDetails)
            {
                const string sql2 = "select id_item, kode_item, nama_item from item where id_item = @id_item";
                td.Item = dbConnection.Query<Model.Item>(sql2, new { id_item = td.ID_Item }).First();
                td.Item.SatuanItemViews = Model.Item.GetSatuanItemViews(dbConnection, td.ID_Item);
                td.SatuanItem = Model.SatuanItem.GetSingle(dbConnection, td.ID_Item, td.ID_Satuan);
            }

            return t.TransferDetails;
        }
    }
}
