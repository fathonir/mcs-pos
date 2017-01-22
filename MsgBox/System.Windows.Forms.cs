using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public class MsgBox
    {
        public static DialogResult Info(string text, MessageBoxButtons buttons = MessageBoxButtons.OK, IWin32Window owner = null)
        {
            if (owner != null)
                return MessageBox.Show(owner, text, "Informasi", buttons, MessageBoxIcon.Information);
            else
                return MessageBox.Show(text, "Informasi", buttons, MessageBoxIcon.Information);
        }

        public static DialogResult Warning(string text, MessageBoxButtons buttons = MessageBoxButtons.OK, IWin32Window owner = null)
        {
            if (owner != null)
                return MessageBox.Show(owner, text, "Perhatian", buttons, MessageBoxIcon.Warning);
            else
                return MessageBox.Show(text, "Perhatian", buttons, MessageBoxIcon.Warning);
        }

        public static DialogResult Question(string text, MessageBoxButtons buttons = MessageBoxButtons.OK, IWin32Window owner = null)
        {
            if (owner != null)
                return MessageBox.Show(owner, text, "Konfirmasi", buttons, MessageBoxIcon.Question);
            else
                return MessageBox.Show(text, "Konfirmasi", buttons, MessageBoxIcon.Question);
        }

        public static DialogResult Error(string text, MessageBoxButtons buttons = MessageBoxButtons.OK, IWin32Window owner = null)
        {
            if (owner != null)
                return MessageBox.Show(owner, text, "Error", buttons, MessageBoxIcon.Error);
            else
                return MessageBox.Show(text, "Error", buttons, MessageBoxIcon.Error);
        }
    }
}
