using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace MCS_POS.Model
{
    public class Item
    {
        public Guid Guid { get; set; }

        public int ID_Item { get; set; }
        public string Kode_Item { get; set; }
        public string Nama_Item { get; set; }
        public int ID_Jenis_Item { get; set; }
        public int? ID_Merek_Item { get; set; }
        public string Nama_Rak { get; set; }
        public string Keterangan { get; set; }
        public bool Is_Dijual { get; set; }
        public int? ID_Supplier { get; set; }
        public int Stok_Minimium { get; set; }
        public int Jenis_Harga_Jual { get; set; }
        public float Persen_Harga_Jual { get; set; }
        public bool Is_Konsinyasi { get; set; }

        // References
        public SatuanItem SatuanDasar { get; set; }
        public List<SatuanItem> SatuanItems { get; set; }
        public IEnumerable<Satuan> Satuans { get; set; }
        public List<SatuanItemView> SatuanItemViews { get; set; }

        public static Item GetSingle(IDbConnection dbConnection, int id_item)
        {
            // Ambil Item
            var item = dbConnection.Query<Item>("select * from item where id_item = " + id_item).SingleOrDefault();
            return item;
        }

        public static SatuanItem GetSatuanDasar(IDbConnection dbConnection, Item item)
        {
            // Ambil Satuan Dasar
            var satuanItem = dbConnection.Query<SatuanItem>(
                "SELECT * FROM satuan_item WHERE id_item = @id_item AND is_satuan_dasar = 1", item)
                .Single();
            satuanItem.Satuan = Model.Satuan.GetSingle(dbConnection, satuanItem.ID_Satuan);

            return satuanItem;
        }

        public static bool HasTransaction(IDbConnection dbConnection, int id_item, int id_satuan)
        {
            var saldoAwal = dbConnection.ExecuteScalar<int>("select count(*) from saldo_awal where id_item = " + id_item + " AND id_satuan = " + id_satuan);
            var penjualan = dbConnection.ExecuteScalar<int>("select count(*) from penjualan_detail where id_item = " + id_item + " AND id_satuan = " + id_satuan);
            var pembelian = dbConnection.ExecuteScalar<int>("select count(*) from pembelian_detail where id_item = " + id_item + " AND id_satuan = " + id_satuan);
            var transfer = dbConnection.ExecuteScalar<int>("select count(*) from transfer_detail where id_item = " + id_item + " AND id_satuan = " + id_satuan);

            return (saldoAwal > 0) || (penjualan > 0) || (pembelian > 0) || (transfer > 0);
        }

        public static bool CanRetur(IDbConnection dbConnection, Item item, Departemen dept)
        {
            var sql = 
                @"SELECT COUNT(*) FROM konsinyasi_detail kd
                JOIN konsinyasi k ON k.id_konsinyasi = kd.id_konsinyasi
                WHERE 
                    jumlah - jumlah_keluar - jumlah_retur > 0 AND
                    k.id_departemen = @id_departemen AND 
                    kd.id_item = @id_item";

            var count = dbConnection.ExecuteScalar<int>(sql, new { id_departemen = dept.ID_Departemen, id_item = item.ID_Item });

            return (count > 0);
        }

        public static Item FindItemByKode(IDbConnection dbConnection, string kode_item)
        {
            const string sql = "select * from item where kode_item = @kode_item";
            return dbConnection.Query<Item>(sql, new { kode_item = kode_item }).FirstOrDefault();
        }

        public static IEnumerable<Satuan> GetItemSatuans(IDbConnection dbConnection, int id_item)
        {
            const string sql =
                @"SELECT satuan.* FROM satuan_item
                JOIN satuan ON satuan.id_satuan = satuan_item.id_satuan
                WHERE satuan_item.id_item = @id_item";

            return dbConnection.Query<Satuan>(sql, new { id_item = id_item });
        }

        public static void FillAllItemsbyDepartemen(IDbConnection dbConnection, DataTable dataTable, int id_departemen)
        {
            const string sql =
                @"SELECT 
                    item.id_item, 
                    kode_item, 
                    satuan_item.barcode, 
                    nama_item,
                    satuan.nama_satuan, 
                    (stok_item.stok / satuan_item.konversi_jumlah) as stok,
                    item.nama_rak, 
                    jenis_item.nama_jenis_item,
                    merek_item.nama_merek_item,
                    satuan_item.harga_pokok,
                    satuan_item.harga_jual,
                    item.stok_minimum,
                    supplier.nama_supplier,
                    item.keterangan
                FROM item
                JOIN satuan_item on satuan_item.id_item = item.id_item
                JOIN satuan on satuan.id_satuan = satuan_item.id_satuan
                LEFT JOIN stok_item on stok_item.id_item = item.id_item and stok_item.id_departemen = @id_departemen
                JOIN jenis_item on jenis_item.id_jenis_item = item.id_jenis_item
                LEFT JOIN merek_item on merek_item.id_merek_item = item.id_merek_item
                LEFT JOIN supplier on supplier.id_supplier = item.id_supplier
                ORDER BY item.nama_item ASC, satuan.nama_satuan ASC";

            using(var command = (dbConnection as MySqlConnection).CreateCommand())
            {
                if (dataTable == null) { dataTable = new DataTable(); }
                dataTable.Clear();

                command.CommandText = sql;
                command.Parameters.AddWithValue("@id_departemen", id_departemen);
                var reader = command.ExecuteReader();
                dataTable.Load(reader);
                reader.Close();
            }
        }

        public static bool Add(IDbTransaction transaction, Item item)
        {
            const string sql =
                "insert into item (kode_item, nama_item, id_jenis_item, id_merek_item, nama_rak, keterangan, is_dijual, jenis_harga_jual, persen_harga_jual, id_supplier, is_konsinyasi, guid) " +
                "values (@kode_item, @nama_item, @id_jenis_item, @id_merek_item, @nama_rak, @keterangan, @is_dijual, @jenis_harga_jual, @persen_harga_jual, @id_supplier, @is_konsinyasi, @guid)";
            
            // execute
            var affected = transaction.Connection.Execute(sql, item, transaction);

            // jika terinsert, ambil id_item
            if (affected > 0)
            {
                item.ID_Item = transaction.Connection.Query<int>("SELECT last_insert_id()", null, transaction).Single();

                // Insert Stok
                const string sql2 =
                    @"insert into stok_item (id_item, id_departemen)
                      select @id_item, id_departemen from departemen";
                affected += transaction.Connection.Execute(sql2, new { id_item = item.ID_Item }, transaction);
            }

            return (affected > 0);
        }

        public static int Update(IDbTransaction transaction, Item item)
        {
            const string sql =
                @"update item set 
                    kode_item = @kode_item,
                    nama_item = @nama_item,
                    id_jenis_item = @id_jenis_item,
                    id_merek_item = @id_merek_item,
                    nama_rak = @nama_rak,
                    keterangan = @keterangan,
                    is_dijual = @is_dijual,
                    id_supplier = @id_supplier
                where id_item = @id_item";

            return transaction.Connection.Execute(sql, item, transaction);
        }

        public static List<SatuanItemView> GetSatuanItemViews(IDbConnection dbConnection, int id_item)
        {
            const string sql =
                @"select satuan.id_satuan, satuan.nama_satuan, konversi_jumlah, is_satuan_dasar, harga_pokok, harga_jual
                from satuan_item 
                join satuan on satuan.id_satuan = satuan_item.id_satuan
                where id_item = @id_item order by konversi_jumlah desc";

            return dbConnection.Query<SatuanItemView>(sql, new { id_item = id_item }).ToList();
        }

        public static bool UpdateHargaJual(IDbTransaction t, int id_item, int id_satuan, int harga_jual)
        {
            const string sql = "UPDATE satuan_item SET harga_jual = @harga_jual WHERE id_item = @id_item AND id_satuan = @id_satuan";
            
            return (t.Connection.Execute(sql, new {
                id_item = id_item,
                id_satuan = id_satuan,
                harga_jual = harga_jual
            }, t) > 0);
        }
    }

    public class SatuanItem
    {
        public int ID_Satuan_Item { get; set; }
        public int ID_Item { get; set; }
        public int ID_Satuan { get; set; }
        public string Barcode { get; set; }
        public float Konversi_Jumlah { get; set; }
        public bool Is_Satuan_Dasar { get; set; }
        public int Harga_Pokok { get; set; }
        public int Harga_Jual { get; set; }

        // References
        public Item Item { get; set; }
        public Satuan Satuan { get; set; }

        public static SatuanItem GetSingle(IDbConnection dbConnection, int id_item, int id_satuan)
        {
            return dbConnection.Query<SatuanItem>(
                "SELECT * FROM satuan_item WHERE id_item = @id_item AND id_satuan = @id_satuan", new
                {
                    id_item = id_item,
                    id_satuan = id_satuan
                }).SingleOrDefault();
        }

        public static SatuanItem GetSingle(IDbConnection dbConnection, SaldoAwal saldoAwal)
        {
            return GetSingle(dbConnection, saldoAwal.ID_Item, saldoAwal.ID_Satuan);
        }

        public static List<SatuanItem> GetList(IDbConnection dbConnection, Item item, bool isSatuanDasar = false)
        {
            const string sql = "select id_satuan_item, id_item, id_satuan, barcode, konversi_jumlah, is_satuan_dasar, harga_pokok, harga_jual from satuan_item where id_item = @id_item and is_satuan_dasar = @is_satuan_dasar";
            return dbConnection.Query<SatuanItem>(sql, new
            {
                id_item = item.ID_Item,
                is_satuan_dasar = (isSatuanDasar) ? 1 : 0
            }).ToList();
        }

        public static int Add(IDbTransaction transaction, SatuanItem si)
        {
            const string sql =
                "INSERT INTO satuan_item (id_item, id_satuan, konversi_jumlah, barcode, is_satuan_dasar, harga_pokok, harga_jual) " +
                "VALUES (@id_item, @id_satuan, @konversi_jumlah, @barcode, @is_satuan_dasar, @harga_pokok, @harga_jual)";

            var affected = transaction.Connection.Execute(sql, si, transaction);

            // execute insert
            if (affected > 0)
            {
                // get last insert id
                si.ID_Satuan_Item = transaction.Connection.Query<int>("select last_insert_id()", null, transaction).Single();
            }

            return affected;
        }

        public static int Update(IDbTransaction transaction, SatuanItem si)
        {
            const string sql =
                @"UPDATE satuan_item SET 
                    id_satuan = @id_satuan, 
                    konversi_jumlah = @konversi_jumlah, 
                    barcode = @barcode,
                    harga_pokok = @harga_pokok,
                    harga_jual = @harga_jual
                WHERE id_satuan_item = @id_satuan_item";

            return transaction.Connection.Execute(sql, si, transaction);
        }

        public static int Delete(IDbTransaction transaction, int id_satuan_item)
        {
            const string sql = "DELETE FROM satuan_item WHERE id_satuan_item = @id";
            return transaction.Connection.Execute(sql, new { id = id_satuan_item }, transaction);
        }

        public static DataTable GetSchemaTable(IDbConnection dbConnection)
        {
            using (var c = dbConnection.CreateCommand())
            {
                c.CommandText = "SELECT * FROM satuan_item";
                var r = c.ExecuteReader();
                var result = r.GetSchemaTable();
                r.Close();
                return result;
            }
        }
    }

    public class ItemPenjualan
    {
        public int ID_Item { get; set; }
        public string Kode_item { get; set; }
        public string Nama_Item { get; set; }
        public int ID_Satuan { get; set; }
        public string Nama_Satuan { get; set; }
        public int Harga_Jual { get; set; }
        public float Stok { get; set; }

        public static ItemPenjualan GetSingle(IDbConnection dbConnection, int id_item, int id_satuan, int id_departemen)
        {
            const string sql =
                @"SELECT 
                    i.id_item, i.kode_item, i.nama_item, si.id_satuan, s.nama_satuan, si.harga_jual, 
                    ifnull(stok_item.stok / si.konversi_jumlah,0) as stok
                FROM item i
                JOIN satuan_item si on si.id_item = i.id_item
                JOIN satuan s on s.id_satuan = si.id_satuan
                LEFT JOIN stok_item ON stok_item.id_item = i.id_item
                WHERE i.id_item = @id_item and s.id_satuan = @id_satuan and stok_item.id_departemen = @id_departemen";

            return dbConnection.Query<ItemPenjualan>(sql, new
            {
                id_item = id_item,
                id_satuan = id_satuan,
                id_departemen = id_departemen
            }).SingleOrDefault();
        }
    }

    public class SatuanItemView
    {
        public int ID_Satuan { get; set; }
        public string Nama_Satuan { get; set; }
        public float Konversi_Jumlah { get; set; }
        public bool Is_Satuan_Dasar { get; set; }
        public int Harga_Pokok { get; set; }
        public int Harga_Jual { get; set; }
    }
}
