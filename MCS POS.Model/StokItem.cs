using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCS_POS.Model
{
    public class StokItem
    {
        public int ID_Stok_Item { get; set; }
        public int ID_Item { get; set; }
        public int ID_Departemen { get; set; }
        public int Stok { get; set; }
    }
}
