using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;

namespace MCS_POS.Model
{
    public class StokOpname
    {
        public int ID_Stok_Opname { get; set; }
        public int ID_Departemen { get; set; }
        public int ID_Item { get; set; }
        public DateTime Tanggal_Opname { get; set; }

        public int Opname_Masuk { get; set; }
        public int Opname_Keluar { get; set; }

        // Ref hitungan transaksi Asli
        public int Awal { get; set; }
        public int Masuk { get; set; }
        public int Keluar { get; set; }
        public int Buku { get; set; }
        public int Fisik { get; set; }
        public int Selisih { get; set; }

        public int Pembelian { get; set; }
        public int Penjualan { get; set; }

        // Ref Value
        public string Kode_Item_Ref { get; set; }
        public string Nama_Item_Ref { get; set; }
        public string Nama_Satuan_Ref { get; set; }

        // Ref Object
        public Model.Item Item { get; set; }
        public Model.Departemen Departemen { get; set; }

        public static List<StokOpname> GetList(IDbConnection dbConnection, Departemen departemen, DateTime tanggal)
        {
            // Tanggal 01 dari bulan tanggal terpilih
            var awal = new DateTime(tanggal.Year, tanggal.Month, 1);
            
            // batas akhir hingga jam 23:59:59
            var akhir = tanggal.Date.AddDays(1d).AddSeconds(-1d);

            const string sql =
                @"select buku.*, 
	                awal+masuk-keluar as buku, 
                    opname_masuk, opname_keluar,
	                awal+masuk-keluar+ifnull(opname_masuk,0)-ifnull(opname_keluar,0) as fisik,
                    so.id_stok_opname
                from (
	                select i.id_item, i.kode_item as kode_item_ref, i.nama_item as nama_item_ref, s.nama_satuan as nama_satuan_ref, 
		                /* Awal Bulan */
		                ifnull((select saldo from kartu_stok ks where ks.id_item = i.id_item and ks.tipe = 'SA' and ks.waktu_transaksi = @tanggalAwal),0) as awal,
        
		                /* Transaksi Masuk */
		                ifnull((select SUM(masuk) from kartu_stok ks where ks.id_item = i.id_item and ks.masuk > 0 and ks.waktu_transaksi BETWEEN @awal AND @akhir),0) as masuk,
	  
		                /* Transaksi Keluar */
		                ifnull((select SUM(keluar) from kartu_stok ks where ks.id_item = i.id_item and ks.keluar > 0 and ks.waktu_transaksi BETWEEN @awal AND @akhir),0) as keluar 
	                from item i
	                join satuan_item si on si.id_item = i.id_item and si.is_satuan_dasar = 1
	                join satuan s on s.id_satuan = si.id_satuan) buku
                left join stok_opname so on so.id_item = buku.id_item and so.id_departemen = @id_departemen and so.tanggal_opname = @tanggalAkhir";

            var stokOpnames = dbConnection.Query<StokOpname>(sql, new {
                id_departemen = departemen.ID_Departemen,
                tanggalAwal = awal.Date,
                awal = awal,
                akhir = akhir,
                tanggalAkhir = akhir.Date
            });

            return stokOpnames.ToList();
        }

        public static void FillDataTable(DataTable dt, IDbConnection dbConnection, Departemen departemen, DateTime tanggal)
        {
            
        }

        public static StokOpname GetSingleForUpdate(IDbConnection dbConnection, int id_stok_opname)
        {
            return dbConnection.Query<StokOpname>("SELECT * FROM stok_opname WHERE id_stok_opname = " + id_stok_opname).Single();
        }

        public static StokOpname GetSingleForAdd(IDbConnection dbConnection, int id_departemen, Item item, DateTime tanggal_opname)
        {
            var stokOpname = new StokOpname();

            stokOpname.ID_Departemen = id_departemen;
            stokOpname.ID_Item = item.ID_Item;
            stokOpname.Item = item;
            stokOpname.Tanggal_Opname = tanggal_opname;

            // Periode : Tanggal 01 awal bulan hingga tanggal opname jam 23:59:59
            var tanggalAwal = new DateTime(tanggal_opname.Year, tanggal_opname.Month, 1);
            var tanggalAkhir = tanggal_opname.Date.AddDays(1d).AddSeconds(-1d);

            // Saldo Awal Bulan
            stokOpname.Awal = dbConnection.ExecuteScalar<int>(
                @"SELECT sa.jumlah * si.konversi_jumlah FROM saldo_awal sa
                JOIN satuan_item si ON si.id_item = sa.id_item AND si.id_satuan = sa.id_satuan
                WHERE sa.id_item = @id_item and tanggal_saldo_awal = @tanggal_saldo_awal", new
                {
                    id_item = item.ID_Item,
                    tanggal_saldo_awal = tanggalAwal
                });

            // Item Masuk (Pembelian)
            stokOpname.Pembelian = dbConnection.ExecuteScalar<int>(
                @"SELECT SUM(jumlah * konversi_jumlah) FROM pembelian_detail pd
                JOIN pembelian p ON p.id_pembelian = pd.id_pembelian
                JOIN satuan_item si ON si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                WHERE pd.id_item = @id_item AND waktu_transaksi BETWEEN @tanggal_awal AND @tanggal_akhir", new
                {
                    id_item = item.ID_Item,
                    tanggal_awal = tanggalAwal,
                    tanggal_akhir = tanggalAkhir
                });

            // Item Masuk (opname masuk)
            stokOpname.Opname_Masuk = dbConnection.ExecuteScalar<int>(
                @"SELECT SUM(opname_masuk) FROM stok_opname 
                WHERE id_item = @id_item AND tanggal_opname BETWEEN @tanggal_awal AND @tanggal_akhir", new 
                {
                    id_item = item.ID_Item,
                    tanggal_awal = tanggalAwal,
                    tanggal_akhir = tanggalAkhir
                });
            
            
            // Item Keluar (Penjualan)
            stokOpname.Penjualan = dbConnection.ExecuteScalar<int>(
                @"SELECT SUM((jumlah - jumlah_refund) * konversi_jumlah) FROM penjualan_detail pd
                JOIN penjualan p ON p.id_penjualan = pd.id_penjualan
                JOIN satuan_item si ON si.id_item = pd.id_item AND si.id_satuan = pd.id_satuan
                WHERE pd.id_item = @id_item AND p.waktu_transaksi BETWEEN @tanggal_awal AND @tanggal_akhir", new
                {
                    id_item = item.ID_Item,
                    tanggal_awal = tanggalAwal,
                    tanggal_akhir = tanggalAkhir
                });

            // Item Masuk (opname keluar)
            stokOpname.Opname_Keluar = dbConnection.ExecuteScalar<int>(
                @"SELECT SUM(opname_keluar) FROM stok_opname 
                WHERE id_item = @id_item AND tanggal_opname BETWEEN @tanggal_awal AND @tanggal_akhir", new
                {
                    id_item = item.ID_Item,
                    tanggal_awal = tanggalAwal,
                    tanggal_akhir = tanggalAkhir
                });

            // Perhitungan stok buku seharusnya
            stokOpname.Masuk = stokOpname.Pembelian + stokOpname.Opname_Masuk;
            stokOpname.Keluar = stokOpname.Penjualan + stokOpname.Opname_Keluar;
            stokOpname.Buku = stokOpname.Awal + stokOpname.Masuk - stokOpname.Keluar;

            return stokOpname;
        }

        public static bool Add(IDbTransaction t, StokOpname so)
        {
            // query insert stok opname
            const string sql = 
                @"INSERT INTO stok_opname (id_departemen, id_item, tanggal_opname, opname_masuk, opname_keluar)
                VALUES (@id_departemen, @id_item, @tanggal_opname, @opname_masuk, @opname_keluar)";

            var affected = t.Connection.Execute(sql, so, t);
            
            if (affected > 0)
            {
                // Update ID primary key
                so.ID_Stok_Opname = t.Connection.ExecuteScalar<int>("SELECT last_insert_id()", null, t);

                // Update stok sesuai data fisik
                const string sql2 = "UPDATE stok_item SET stok = @fisik WHERE id_item = @id_item AND id_departemen = @id_departemen";
                affected += t.Connection.Execute(sql2, so, t);

                // Ambil stok utk dijadikan saldo
                // const string sql3 = "SELECT stok FROM stok_item WHERE id_departemen = @id_departemen AND id_item = @id_item";
                // var saldo = t.Connection.ExecuteScalar(sql3, so, t);

                // Insert Kartu Stok
                // const string sql4 = "INSERT INTO kartu_stok (id_departemen, id_item, tipe, waktu_transaksi, masuk, keluar, saldo)";
            }

            return (affected > 0);
        }

        public static bool Update(IDbTransaction t, StokOpname so)
        {   
            // Update stok item dengan fisik sekarang
            var affected = t.Connection.Execute("update stok_item set stok = @fisik where id_departemen = @id_departemen and id_item = @id_item", so, t);
            
            // Update row stok_opname
            affected = t.Connection.Execute("update stok_opname set opname_masuk = @opname_masuk, opname_keluar = @opname_keluar where id_stok_opname = @id_stok_opname", so, t);

            return (affected > 0);
        }

        public static bool Delete(IDbTransaction t, StokOpname so)
        {
            var affected = t.Connection.Execute("delete from stok_opname where id_stok_opname = @id_stok_opname", so, t);

            return (affected > 0);
        }
    }
}
