using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS_POS
{
    public partial class EditorBaseForm : Form
    {
        public enum EditMode { Add, Edit }

        public IDbConnection DbConnection { get; set; }
        public TabControl TabControlReference { get; set; }
        public TabPage TabPageReference { get; set; }
        public Button CloseButtonReference { get; set; }

        /// <summary>
        /// Departemen yang sedang aktif
        /// </summary>
        public Model.Departemen DepartemenAktif { get; set; }

        /// <summary>
        /// User yang sedang login
        /// </summary>
        public Model.User UserLogin { get; set; }

        /// <summary>
        /// Konfigurasi aplikasi
        /// </summary>
        public List<Model.Config> Configs { get; set; }

        /// <summary>
        /// Primary Key untuk edit
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Mode Edit
        /// </summary>
        public EditMode EditorMode { get; set; }

        public EditorBaseForm()
        {
            InitializeComponent();
        }

        private void EditorBaseForm_Load(object sender, EventArgs e)
        {
            if (TabControlReference != null)
            {
                // Membuat handle tab baru
                TabPageReference = new TabPage(this.Text);

                // Tambahkan ke tabcontrol
                TabControlReference.TabPages.Add(TabPageReference);

                // Tampilkan
                TabControlReference.Visible = true;

                // Langsung di select
                TabControlReference.SelectedTab = TabPageReference;
            }

            // Full screen mdi
            WindowState = FormWindowState.Maximized;
        }

        private void EditorBaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TabControlReference != null)
            {
                // Hapus tabpage
                TabPageReference.Dispose();

                if (TabControlReference.TabPages.Count == 0)
                {
                    // tab control dihilangkan ketika tidak mempunya tabpage sama sekali
                    TabControlReference.Visible = false;
                }
            }
        }

        private void EditorBaseForm_Activated(object sender, EventArgs e)
        {
            if (TabControlReference != null)
            {
                // tab page di select
                TabControlReference.SelectedTab = TabPageReference;
            }
        }

        protected void ExceptionBox(Exception ex)
        {
            using (var dialog = new ExceptionForm())
            {
                dialog.MessageTextBox.Text = ex.Message;
                dialog.StackTraceTextBox.Text = ex.StackTrace;
                System.Media.SystemSounds.Asterisk.Play();
                dialog.ShowDialog(this);
            }
        }
    }
}
