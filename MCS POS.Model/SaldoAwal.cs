using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MCS_POS.Model
{
    public class SaldoAwal
    {
        public int ID_Saldo_Awal { get; set; }
        public int ID_Departemen { get; set; }
        public DateTime Tanggal_Saldo_Awal { get; set; }
        public int ID_Item { get; set; }
        public int Jumlah { get; set; }
        public int ID_Satuan { get; set; }
        public int Harga_Beli { get; set; }
        public int Sub_Total { get; set; }

        public Model.Item Item { get; set; }
        public Model.SatuanItem SatuanItem { get; set; }
        public Model.Departemen Departemen { get; set; }

        public static SaldoAwal GetSingle(IDbConnection dbConnection, int id_saldo_awal)
        {
            var saldoAwal = dbConnection.Query<SaldoAwal>(
                "SELECT * FROM saldo_awal WHERE id_saldo_awal = @id", 
                new { id = id_saldo_awal })
                .SingleOrDefault();

            if (saldoAwal != null)
            {
                saldoAwal.SatuanItem = Model.SatuanItem.GetSingle(dbConnection, saldoAwal.ID_Item, saldoAwal.ID_Satuan);
            }

            return saldoAwal;
        }

        public static SaldoAwal GetSingle(IDbConnection dbConnection, Item item, DateTime tanggalSaldoAwal)
        {
            const string sql = "SELECT * FROM saldo_awal WHERE id_item = @id_item AND tanggal_saldo_awal = @tanggal_saldo_awal";
            var saldoAwal = dbConnection.Query<SaldoAwal>(sql, new { 
                id_item = item.ID_Item,
                tanggal_saldo_awal = tanggalSaldoAwal
            }).SingleOrDefault();

            // Set Parent object
            if (saldoAwal != null) { saldoAwal.Item = item; }

            return saldoAwal;
        }

        public static IEnumerable<SaldoAwal> GetList(IDbConnection dbConnection, int id_departemen, DateTime tanggal_saldo_awal)
        {
            var result = dbConnection.Query<SaldoAwal>(
                "SELECT * FROM saldo_awal WHERE id_departemen = @id_departemen AND tanggal_saldo_awal = @tanggal_saldo_awal ORDER BY id_saldo_awal", new
                {
                    id_departemen = id_departemen,
                    tanggal_saldo_awal = tanggal_saldo_awal
                });

            foreach (var saldoAwal in result)
            {
                // Item dan satuannya
                saldoAwal.Item = dbConnection.Query<Item>("SELECT id_item, kode_item, nama_item FROM item WHERE id_item = " + saldoAwal.ID_Item).Single();
                saldoAwal.Item.SatuanItemViews = Model.Item.GetSatuanItemViews(dbConnection, saldoAwal.ID_Item);
            }

            return result;
        }

        public static bool Add(IDbTransaction t, SaldoAwal sa)
        {
            // Insert data
            var affected = t.Connection.Execute(
                "INSERT INTO saldo_awal (id_departemen, tanggal_saldo_awal, id_item, jumlah, id_satuan, harga_beli, sub_total) " +
                "VALUES (@id_departemen,@tanggal_saldo_awal,@id_item,@jumlah,@id_satuan,@harga_beli,@sub_total)", sa, t);

            // Ambil PK
            sa.ID_Saldo_Awal = t.Connection.ExecuteScalar<int>("SELECT last_insert_id()");

            // Update stok
            affected += t.Connection.Execute(
                "UPDATE stok_item SET stok = stok + (@jumlah * @konversi_jumlah) WHERE id_item = @id_item AND id_departemen = @id_departemen", new
                {
                    jumlah = sa.Jumlah,
                    konversi_jumlah = sa.SatuanItem.Konversi_Jumlah,
                    id_item = sa.ID_Item,
                    id_departemen = sa.ID_Departemen
                }, t);

            return (affected > 0);
        }

        public static bool Update(IDbTransaction t, SaldoAwal sa)
        {
            // Ambil SaldoAwal lama
            var oldSA = Model.SaldoAwal.GetSingle(t.Connection, sa.ID_Saldo_Awal);

            // Reset stok
            var affected = t.Connection.Execute(
                "UPDATE stok_item SET stok = stok - (@jumlah * @konversi_jumlah) WHERE id_item = @id_item AND id_departemen = @id_departemen", new
                {
                    jumlah = oldSA.Jumlah,
                    konversi_jumlah = oldSA.SatuanItem.Konversi_Jumlah,
                    id_item = oldSA.ID_Item,
                    id_departemen = oldSA.ID_Departemen
                }, t);
            
            // Update data dengan yg baru
            affected += t.Connection.Execute(
                "UPDATE saldo_awal SET jumlah = @jumlah, id_satuan = @id_satuan, harga_beli = @harga_beli, sub_total = @sub_total " +
                "WHERE id_departemen = @id_departemen AND tanggal_saldo_awal = @tanggal_saldo_awal AND id_item = @id_item", sa, t);

            // Update stok
            affected += t.Connection.Execute(
                "UPDATE stok_item SET stok = stok + (@jumlah * @konversi_jumlah) WHERE id_item = @id_item AND id_departemen = @id_departemen", new
                {
                    jumlah = sa.Jumlah,
                    konversi_jumlah = sa.SatuanItem.Konversi_Jumlah,
                    id_item = sa.ID_Item,
                    id_departemen = sa.ID_Departemen
                }, t);

            return (affected > 0);
        }

        public static bool Delete(IDbTransaction t, SaldoAwal sa)
        {
            // Ambil SaldoAwal lama
            var oldSA = Model.SaldoAwal.GetSingle(t.Connection, sa.ID_Saldo_Awal);

            // Reset stok
            var affected = t.Connection.Execute(
                "UPDATE stok_item SET stok = stok - (@jumlah * @konversi_jumlah) WHERE id_item = @id_item AND id_departemen = @id_departemen", new
                {
                    jumlah = oldSA.Jumlah,
                    konversi_jumlah = oldSA.SatuanItem.Konversi_Jumlah,
                    id_item = oldSA.ID_Item,
                    id_departemen = oldSA.ID_Departemen
                }, t);

            // Delete saldo awal
            affected += t.Connection.Execute(
                "DELETE FROM saldo_awal WHERE id_departemen = @id_departemen AND tanggal_saldo_awal = @tanggal_saldo_awal AND id_item = @id_item", sa, t);

            return (affected > 0);
        }
    }
}