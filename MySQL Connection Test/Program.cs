using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySQL_Connection_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Default file name
            var configFile = "config.ini";
            
            // Jika ada parameter, menggunakan parameter
            if (args.Count() == 1)
            {
                configFile = args[0];
            }

            // Load config.ini
            var ConfigINI = new System.IO.IniFile(configFile);

            // build connection string
            var csBuilder = new MySqlConnectionStringBuilder();
            csBuilder.Server = ConfigINI.GetString("db", "server", "localhost");
            csBuilder.Port = Convert.ToUInt32(ConfigINI.GetString("db", "port", "3306"));
            csBuilder.UserID = ConfigINI.GetString("db", "user_id", "root");
            csBuilder.Password = ConfigINI.GetString("db", "password", "");
            csBuilder.Database = ConfigINI.GetString("db", "database", "app_pos");

            var DbConnection = new MySqlConnection(csBuilder.GetConnectionString(true));

            try
            {
                Console.WriteLine("Start Connection ...");
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("Server : " + csBuilder.Server);
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("Port : " + csBuilder.Port);
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("User : " + csBuilder.UserID);
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("Password : " + csBuilder.Password);
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("Database : " + csBuilder.Database);
                System.Threading.Thread.Sleep(50);

                DbConnection.Open();
                Console.WriteLine("Connection Successfull ! ");
                Console.WriteLine("Server Version : " + DbConnection.ServerVersion);
                DbConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Error: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
