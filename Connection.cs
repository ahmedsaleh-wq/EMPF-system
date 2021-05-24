using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace EMPF
{
    class Connection
    {
        private MySqlConnection connection;
        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;
        public Connection() {
            try
            {
                server = "sql2.freemysqlhosting.net";
                database = "sql2395628";
                uid = "sql2395628";
                password = "qS6*iH5*";
                port = "3306";
                string connectionString;
                connectionString = "Server=" + server + ";" + "port=" + port + ";" + "Database=" +
                database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";CHARSET=utf8;";

                connection = new MySqlConnection(connectionString);
                connection.Open();

            }
            catch
            {
               
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
