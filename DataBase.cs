using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SportCLUB
{
    public class DataBase
    {
        public DataBase()
        {
            
        }

        public DataBase(string login, string password)
        {
            DataBase.username = login; DataBase.password = password;
        }

        static string serverIp = "192.168.0.29";        // IP сервера
        static int serverPort = 1433;                   // Порт сервера
        static string dataBaseName = "SportCLUB";       // Имя базы данных
        static string username;                         // Пользователь SQL Server
        static string password;                         // Пароль пользователя

        SqlConnection con = new SqlConnection($@"Data Source={serverIp}, {serverPort};Initial Catalog={dataBaseName};Integrated Security=False;User ID={username};Password={password}");
        public void OpenCon()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void CloseCon()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return con;
        }
    }
}
