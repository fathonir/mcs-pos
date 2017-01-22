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
    public class Bank
    {
        public int ID_Bank { get; set; }
        public string Nama_Bank { get; set; }

        public static IEnumerable<Bank> GetList(IDbConnection dbConnection)
        {
            const string query = "select * from bank";
            return dbConnection.Query<Bank>(query);
        }
    }
}
