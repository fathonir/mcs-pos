using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MCS_POS.Persediaan
{
    public partial class StokOpnameForm : MCS_POS.EditorBaseForm
    {
        public new Model.Departemen DepartemenAktif { get; set; }

        private MySqlDataAdapter DataAdapter { get; set; }
        private DataTable DGVDataTable = new DataTable();
        private BindingSource DGVBindingSource = new BindingSource();

        public StokOpnameForm()
        {
            InitializeComponent();
        }

        private void StokOpnameForm_Load(object sender, EventArgs e)
        {
            const string sql =
                @"select
                    ifnull(so.id_stok_opname,-1) as id_stok_opname,
                    buku.*, 
	                awal+masuk-keluar as buku, 
                    opname_masuk, opname_keluar,
	                awal+masuk-keluar+ifnull(opname_masuk,0)-ifnull(opname_keluar,0) as fisik,
                    /* Selisih = Fisik-Buku */
                    (awal+masuk-keluar+ifnull(opname_masuk,0)-ifnull(opname_keluar,0))-(awal+masuk-keluar) as selisih
                from (
	                select i.id_item, i.kode_item, i.nama_item, s.nama_satuan, 
		                /* Awal Bulan */
		                ifnull((select saldo from kartu_stok ks where ks.id_item = i.id_item and ks.tipe = 'SA' and ks.id_departemen = @id_departemen AND ks.waktu_transaksi = @tanggalAwal),0) as awal,
        
		                /* Transaksi Masuk */
		                ifnull((select SUM(masuk) from kartu_stok ks where ks.id_item = i.id_item and ks.masuk > 0 and ks.id_departemen = @id_departemen AND ks.waktu_transaksi BETWEEN @awal AND @akhir),0) as masuk,
	  
		                /* Transaksi Keluar */
		                ifnull((select SUM(keluar) from kartu_stok ks where ks.id_item = i.id_item and ks.keluar > 0 and ks.id_departemen = @id_departemen AND ks.waktu_transaksi BETWEEN @awal AND @akhir),0) as keluar 
	                from item i
	                join satuan_item si on si.id_item = i.id_item and si.is_satuan_dasar = 1
	                join satuan s on s.id_satuan = si.id_satuan) buku
                left join stok_opname so on so.id_item = buku.id_item and so.id_departemen = @id_departemen and so.tanggal_opname = @tanggalAkhir";

            DataAdapter = new MySqlDataAdapter(sql, DbConnection as MySqlConnection);
            DataAdapter.SelectCommand.Parameters.Add("@tanggalAwal", MySqlDbType.Date);
            DataAdapter.SelectCommand.Parameters.Add("@awal", MySqlDbType.DateTime);
            DataAdapter.SelectCommand.Parameters.Add("@akhir", MySqlDbType.DateTime);
            DataAdapter.SelectCommand.Parameters.Add("@id_departemen", MySqlDbType.Int32);
            DataAdapter.SelectCommand.Parameters.Add("@tanggalAkhir", MySqlDbType.Date);

            DGVBindingSource.DataSource = DGVDataTable;
            DGV.DataSource = DGVBindingSource;

        }

        private void StokOpnameForm_Shown(object sender, EventArgs e)
        {
            label3.Text = "Stok dihitung dari : " + 
                (new DateTime(TanggalOpname.Value.Year, TanggalOpname.Value.Month, 1)).ToString("d") + " s.d. " +
                TanggalOpname.Value.Date.AddDays(1d).AddSeconds(-1d).ToString("G");

            RefreshDGV();
        }

        public void RefreshDGV()
        {
            /// Tampilan kolom Awal akan muncul sesuai dengan 
            /// tanggal setting periode awal program.
            /// Contoh : 
            /// Periode Awal Transaksi = Februari 2015
            /// Maka, jika tanggal Opname dipilih bulan Februari 2015, maka kolom Awal akan muncul
            /// sesuai dengan inputan Saldo Awal.
            /// Jika tanggal Opname dipilih bulan Maret 2015, maka kolom Awal = 0 (karena bukan
            /// periode awal transaksi)
            /// 

            DGVDataTable.Clear();

            // Tanggal 01 dari bulan tanggal terpilih
            var awal = new DateTime(TanggalOpname.Value.Year, TanggalOpname.Value.Month, 1);

            // batas akhir hingga jam 23:59:59
            var akhir = TanggalOpname.Value.Date.AddDays(1d).AddSeconds(-1d);

            DataAdapter.SelectCommand.Parameters["@tanggalAwal"].Value = awal;
            DataAdapter.SelectCommand.Parameters["@awal"].Value = awal;
            DataAdapter.SelectCommand.Parameters["@akhir"].Value = akhir;
            DataAdapter.SelectCommand.Parameters["@id_departemen"].Value = DepartemenAktif.ID_Departemen;
            DataAdapter.SelectCommand.Parameters["@tanggalAkhir"].Value = TanggalOpname.Value;

            DataAdapter.Fill(DGVDataTable);
        }

        private void TanggalOpname_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = "Stok dihitung dari : " +
                (new DateTime(TanggalOpname.Value.Year, TanggalOpname.Value.Month, 1)).ToString("d") + " s.d. " +
                TanggalOpname.Value.Date.AddDays(1d).AddSeconds(-1d).ToString("G");

            // Tampilkan ulang dgv
            RefreshDGV();
        }

        private void DGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var currentCell = DGV.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (e.ColumnIndex == ColumnFisik.DisplayIndex)
            {
                if (currentCell.Value != null)
                {
                    currentCell.Value = int.Parse(currentCell.Value.ToString(), NumberStyles.Number).ToString();
                }
            }
        }

        private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // untuk kolom jumlah dan harga beli
            if (e.ColumnIndex == ColumnFisik.DisplayIndex)
            {
                int result = 0;
                e.Cancel = !int.TryParse(e.FormattedValue.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture, out result);
            }
        }

        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var currentRow = DGV.Rows[e.RowIndex];
            var value = currentRow.Cells[e.ColumnIndex].Value;

            if (value != null)
            {
                int result = 0;

                // Untuk kolom jumlah dan harga beli
                if (e.ColumnIndex == ColumnFisik.DisplayIndex)
                {
                    int.TryParse(value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture, out result);
                    currentRow.Cells[e.ColumnIndex].Value = result.ToString("N0");

                    // Hitung kolom selisih = fisik - buku
                    currentRow.Cells[ColumnSelisih.Name].Value =
                        int.Parse(currentRow.Cells[ColumnFisik.DisplayIndex].Value.ToString(), NumberStyles.Number) -
                        int.Parse(currentRow.Cells[ColumnBuku.DisplayIndex].Value.ToString(), NumberStyles.Number);
                }
            }
        }

        private void DGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == ColumnFisik.DisplayIndex)
            {
                if (e.ThrowException)
                {
                    e.Cancel = true;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Proses data yg ada selisih saja atau yg punya id_stok_opname
            var filteredRows =
                DGV.Rows.Cast<DataGridViewRow>()
                .Where(row => Convert.ToInt32(row.Cells[ColumnSelisih.Name].Value) != 0 || Convert.ToInt32(row.Cells[ColumnID_Stok_Opname.Name].Value) > 0);

            var transaction = DbConnection.BeginTransaction();

            foreach (var row in filteredRows)
            {
                var selisih = Convert.ToInt32(row.Cells[ColumnSelisih.Name].Value);

                // Untuk Item baru
                if (Convert.ToInt32(row.Cells[ColumnID_Stok_Opname.Name].Value) == -1)
                {
                    // buat object stok opname baru
                    var stokOpname = new Model.StokOpname() { 
                        ID_Departemen = DepartemenAktif.ID_Departemen,
                        ID_Item = Convert.ToInt32(row.Cells[ColumnID_Item.Name].Value),
                        Tanggal_Opname = TanggalOpname.Value.Date,
                        Awal = Convert.ToInt32(row.Cells[ColumnAwal.Name].Value),
                        Fisik = Convert.ToInt32(row.Cells[ColumnFisik.Name].Value),
                        Selisih = selisih
                    };

                    // Jika selisih > 0 : Stok Masuk
                    if (selisih > 0)
                    {
                        stokOpname.Opname_Masuk = selisih;
                    }
                    else // Jika selisih < 0 : Stok Keluar
                    {
                        stokOpname.Opname_Keluar = 0 - selisih;
                    }

                    // Insert StokOpname ke DB
                    Model.StokOpname.Add(transaction, stokOpname);

                    // Insert KartuStok
                    Model.KartuStok.AddStokOpname(transaction, stokOpname);

                    // Update ID PK
                    row.Cells[ColumnID_Stok_Opname.Name].Value = stokOpname.ID_Stok_Opname;
                }
                else // Untuk item lama
                {
                    // Load object
                    var stokOpname = Model.StokOpname.GetSingleForUpdate(DbConnection, Convert.ToInt32(row.Cells[ColumnID_Stok_Opname.Name].Value));
                    stokOpname.Fisik = Convert.ToInt32(row.Cells[ColumnFisik.Name].Value);

                    // hitung fisik sebelumnya
                    var fisikAwal = Convert.ToInt32(row.Cells[ColumnBuku.Name].Value) + stokOpname.Opname_Masuk - stokOpname.Opname_Keluar;


                    // Jika selisih > 0 : Stok Masuk
                    if (selisih > 0)
                    {
                        stokOpname.Opname_Masuk = selisih;
                    }
                    else if (selisih < 0) // Jika selisih < 0 : stok keluar
                    {
                        stokOpname.Opname_Keluar = 0 - selisih;
                    }

                    // Jika selisih mengalami perbedaan / ada perubahan
                    if (stokOpname.Fisik != fisikAwal)
                    { 
                        if (selisih != 0)
                        {
                            // Update stok opname ke db
                            Model.StokOpname.Update(transaction, stokOpname);

                            // Update kartu stok
                            Model.KartuStok.UpdateStokOpname(transaction, stokOpname);
                        }
                        else // Jika selisih kembali ke 0, maka stok opname dihapus
                        {
                            Model.StokOpname.Delete(transaction, stokOpname);

                            // id_stok_opname di set -1 lagi
                            row.Cells[ColumnID_Stok_Opname.Name].Value = -1;
                        }
                    }
                }
            }

            transaction.Commit();

            MessageBox.Show(this, "Data berhasil disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void KeywordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (KeywordTextBox.Text.Trim().Length > 2)
            {
                DGVBindingSource.Filter = "nama_item Like '%" + KeywordTextBox.Text + "%' or nama_satuan Like '%" + KeywordTextBox.Text + "%'";
            }
            else
            {
                DGVBindingSource.Filter = "";
            }
        }

    }
}
