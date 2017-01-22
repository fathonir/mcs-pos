using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MCS_POS.Model
{
    public class Satuan
    {
        public int ID_Satuan { get; set; }
        public string Nama_Satuan { get; set; }
        public string Keterangan_Satuan { get; set; }

        public static Satuan GetSingle(IDbConnection dbConnection, int id_satuan)
        {
            return dbConnection.Query<Satuan>("SELECT * FROM satuan WHERE id_satuan = " + id_satuan).Single();
        }

        public static IEnumerable<Satuan> GetList(IDbConnection dbConnection)
        {
            const string query = "select * from satuan";
            return dbConnection.Query<Satuan>(query);
        }

        public static IEnumerable<Satuan> GetListForSatuanEditor(IDbConnection dbConnection)
        {
            const string query = "select id_satuan, concat('1 ', nama_satuan) as nama_satuan from satuan";
            return dbConnection.Query<Satuan>(query);
        }
    }
}
