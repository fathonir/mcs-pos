using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MCS_POS.Kasir
{

    public class TouchButton : System.Windows.Forms.Button
    {
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            // Highlight touch
            base.UseVisualStyleBackColor = false;
            base.BackColor = Color.LightSkyBlue;
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            
            // Return
            base.BackColor = SystemColors.Control;
            base.UseVisualStyleBackColor = true;
        }
    }
}
