using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS_POS
{
    public partial class ChildBaseForm : Form
    {
        // Control References
        public IDbConnection DbConnection { get; set; }
        public TabControl TabControlReference { get; set; }
        public TabPage TabPageReference { get; set; }
        public Button CloseButtonReference { get; set; }
        
        // Object Model References
        public Model.Departemen DepartemenAktif { get; set; }
        public Model.User UserLogin { get; set; }
        public List<Model.Config> Configs { get; set; }

        // Internal References
        protected IDbDataAdapter Adapter { get; set; }
        protected DbCommandBuilder CommandBuilder { get; set; }
        protected DataSet dataSet = new DataSet();

        public ChildBaseForm()
        {
            InitializeComponent();
        }

        private void ChildBaseForm_Load(object sender, EventArgs e)
        {
            if (TabControlReference != null)
            {
                TabPageReference = new TabPage(this.Text);
                TabControlReference.TabPages.Add(TabPageReference);
                TabControlReference.Visible = true;
                TabControlReference.SelectedTab = TabPageReference;
            }
        }

        private void ChildBaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TabControlReference != null)
            {
                TabPageReference.Dispose();

                if (TabControlReference.TabPages.Count == 0)
                {
                    TabControlReference.Visible = false;
                }
            }
        }

        private void ChildBaseForm_Activated(object sender, EventArgs e)
        {
            if (TabControlReference != null)
            {
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

        private void ChildBaseForm_Shown(object sender, EventArgs e)
        {
            if (TabControlReference != null)
            {
                WindowState = FormWindowState.Maximized;
            }
        }
    }
}
