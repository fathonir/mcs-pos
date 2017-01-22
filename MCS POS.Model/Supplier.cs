using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MCS_POS.Model
{
    public class Supplier
    {
        public int ID_Supplier { get; set; }
        public string Kode_Supplier { get; set; }
        public string Nama_Supplier { get; set; }

        public static Supplier GetSingle(IDbConnection dbConnection, int id_supplier)
        {
            return dbConnection.Query<Supplier>("SELECT * FROM supplier WHERE id_supplier = " + id_supplier).SingleOrDefault();
        }

        public static IEnumerable<Supplier> GetEnumerable(IDbConnection dbConnection)
        {
            return dbConnection.Query<Supplier>("SELECT * FROM supplier");
        }
    }
}
