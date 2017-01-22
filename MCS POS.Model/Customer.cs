using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;

namespace MCS_POS.Model
{
    public class Customer
    {
        public int ID_Customer { get; set; }
        public string Nama_Customer { get; set; }
        public string Alamat_Customer { get; set; }
        public string Telp_Customer { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public static Customer GetSingle(IDbConnection dbConnection, int id_customer)
        {
            return dbConnection.Query<Customer>("SELECT * FROM customer WHERE id_customer = " + id_customer).SingleOrDefault();
        }
    }
}
