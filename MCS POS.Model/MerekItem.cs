using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;

namespace MCS_POS.Model
{
    public class MerekItem
    {
        public int ID_Merek_Item { get; set; }
        public string Nama_Merek_Item { get; set; }

        public static IEnumerable<MerekItem> GetList(IDbConnection dbConnection)
        {
            const string query = "select * from merek_item";
            return dbConnection.Query<MerekItem>(query);
        }
    }
}
