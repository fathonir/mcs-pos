using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MCS_POS.Model
{
    public class JenisItem
    {
        public int ID_Jenis_Item { get; set; }
        public string Nama_Jenis_Item { get; set; }
        public string Keterangan_Jenis_Item { get; set; }

        public static IEnumerable<JenisItem> GetList(IDbConnection dbConnection)
        {
            const string query = "select id_jenis_item, nama_jenis_item, keterangan_jenis_item from jenis_item";
            return dbConnection.Query<JenisItem>(query);
        }
    }
}
