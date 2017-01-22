using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace MCS_POS.Model
{
    public class Departemen
    {
        public int ID_Departemen { get; set; }
        public string Kode_Departemen { get; set; }
        public string Nama_Departemen { get; set; }
        public string Alamat_Departemen { get; set; }
        public string Kota_Departemen { get; set; }
        public string Telp_Departemen { get; set; }

        public static IEnumerable<Departemen> GetDepartemenForCombo(IDbConnection dbConnection, bool withAll = false)
        {
            if (withAll == false)
            {
                var sql = "SELECT id_departemen, nama_departemen FROM departemen";
                return dbConnection.Query<Departemen>(sql);
            }
            else
            {
                var sql = @"
                    SELECT 0 as id_departemen, 'SEMUA CABANG' as nama_departemen UNION ALL
                    SELECT id_departemen, nama_departemen FROM departemen";
                return dbConnection.Query<Departemen>(sql);
            }
        }

        public static Departemen GetSingle(IDbConnection dbConnection, string kode_departemen)
        {
            const string sql = @"SELECT * FROM departemen WHERE kode_departemen = @kode_departemen";
            return dbConnection.Query<Departemen>(sql, new { kode_departemen = kode_departemen }).FirstOrDefault();
        }

        public static Departemen GetSingle(IDbConnection dbConnection, int id_departemen)
        {
            const string sql = @"SELECT * FROM departemen WHERE id_departemen = @id_departemen";
            return dbConnection.Query<Departemen>(sql, new { id_departemen = id_departemen }).FirstOrDefault();
        }
    }
}
