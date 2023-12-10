using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach.Configs
{
    public class ConnectDb
    {
        // private static readonly string ServerName = @"103.101.163.106";
        // private static readonly string tenServer = @"LAPTOP-I7PSPJDI\SQLEXPRESS";
        private static readonly string ServerName = @"localhost";
        private static readonly string DatabaseName = "bookstoredb";

        private static string strConnect = "server=" + ServerName + ";database=" +
           DatabaseName + ";user=root;password=; pooling = false; convert zero datetime=True";


        public ConnectDb() {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Password = "";
            builder.UserID = "root";
            builder.Database = "bookstoredb";
            builder.Server = "localhost";
            builder.Pooling = true;
            
           // strConnect = builder.ToString() + " convert zero datetime=True";
        }

        public static bool CustomExecute(string strQuerry)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(strConnect);
                // SqlConnection connection = new SqlConnection(strConnect);
                connection.Open();
               
                MySqlCommand command = new MySqlCommand(strQuerry, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static DataTable ExecuteReaderTable(string strQuerry)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(strConnect);
                connection.Open();
                MySqlCommand command = new MySqlCommand(strQuerry, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable data = new DataTable();
                adapter.Fill(data);
                connection.Close();
                return data;
            }
            catch
            {
                MessageBox.Show("Lấy dữ liệu lỗi");
                return null;
            }

        }

        public static bool ExecuteNonQuery(string strQuerry)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(strConnect);
                connection.Open();
                MySqlCommand command = new MySqlCommand(strQuerry, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
