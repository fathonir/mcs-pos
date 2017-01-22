using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace System.Windows.Forms
{
    /// <summary>
    /// Fathoni Rokhman DataGridView
    /// </summary>
    /// 

    [Designer(typeof(System.Windows.Forms.Design.ControlDesigner))]
    public class FrDataGridView : DataGridView
    {
        public FrDataGridView()
        {
            DoubleBuffered = true;

            base.EditMode = DataGridViewEditMode.EditOnEnter;
            base.RowHeadersWidth = 25;
            base.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            base.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            base.MultiSelect = false;
        }
    }
}
