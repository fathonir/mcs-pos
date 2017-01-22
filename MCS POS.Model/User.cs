using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MCS_POS.Model
{
    public class User
    {
        public int ID_User { get; set; }
        public string Tipe_User { get; set; }
        public string Username { get; set; }
        public string Nama_User { get; set; }

        public bool Akses_Refund { get; set; }
        public bool Akses_Harga_Jual { get; set; }
        public bool Akses_Data_Penjualan { get; set; }

        /// <summary>
        /// Hanya di isi jika akan ganti password
        /// </summary>
        public string New_Password { get; set; }

        public static User GetSingle(IDbConnection dbConnection, int id_user)
        {
            const string sql = "SELECT * FROM user WHERE id_user = @id_user";
            return dbConnection.Query<User>(sql, new { id_user = id_user }).Single();
        }

        public static List<User> GetListKasirAktif(IDbConnection dbConnection, int id_departemen)
        {
            const string sql = "SELECT * FROM user where tipe_user = @tipe_user and is_aktif = @is_aktif and id_departemen = @id_departemen";

            return dbConnection.Query<User>(sql, new
            {
                tipe_user = "kasir",             // tipe user 'kasir' saja
                is_aktif = 1,                    // hanya user yang aktif yg di load
                id_departemen = id_departemen    
            }).ToList();
        }

        public static List<User> GetListKasir(IDbConnection dbConnection, int id_departemen)
        {
            const string sql = "SELECT * FROM user where tipe_user = @tipe_user and id_departemen = @id_departemen";

            return dbConnection.Query<User>(sql, new
            {
                tipe_user = "kasir",             // tipe user 'kasir' saja
                id_departemen = id_departemen
            }).ToList();
        }

        public static bool UpdatePassword(IDbTransaction transaction, User user)
        {
            const string sql = "UPDATE `user` SET password_hash = sha1(@new_password) WHERE id_user = @id_user";
            return (transaction.Connection.Execute(sql, user, transaction) > 0);
        }
    }
}
