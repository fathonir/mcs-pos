using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS_POS.Kasir
{
    public partial class PrinterSettingForm : Form
    {
        public PrinterSettingForm()
        {
            InitializeComponent();
        }

        private void PrinterSettingForm_Load(object sender, EventArgs e)
        {
            // Populate Printer
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                PrinterComboBox.Items.Add(printer);
            }

            // Load setting
            if (Properties.Settings.Default.KasirPrinterName != string.Empty)
            {
                PrinterComboBox.SelectedItem = Properties.Settings.Default.KasirPrinterName;
            }

            // Populate Spasi
            for (int i = 1; i <= 15; i++)
            {
                SpasiComboBox.Items.Add(i.ToString());
            }

            // Load setting
            SpasiComboBox.SelectedItem = Properties.Settings.Default.KasirPrinterSpace.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var defaultSetting = Properties.Settings.Default;

            // Set properties printer
            if (PrinterComboBox.SelectedItem != null)
            {
                defaultSetting.KasirPrinterName = PrinterComboBox.SelectedItem.ToString();
            }

            // set properties spasi
            defaultSetting.KasirPrinterSpace = int.Parse(SpasiComboBox.SelectedItem.ToString());

            // Save
            defaultSetting.Save();

            this.Close();
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Button).UseVisualStyleBackColor = false;
            (sender as Button).BackColor = Color.LightSkyBlue;
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as Button).BackColor = SystemColors.Control;
            (sender as Button).UseVisualStyleBackColor = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PrinterComboBox.SelectedItem != null && SpasiComboBox.SelectedItem != null)
            {
                var x = new PrintDirect();

                string TestString = "<< PASTIKAN TULISAN INI DIATAS CUTTER >>\r\n----------------------------------------\r\n";

                // Nambahi Enter
                for (int i = 0; i < int.Parse(SpasiComboBox.SelectedItem.ToString()); i++)
                {
                    TestString += "\r\n";
                }

                x.Print(PrinterComboBox.SelectedItem.ToString(), TestString, "TEST ECS POS");
            }
        }
    }
}
