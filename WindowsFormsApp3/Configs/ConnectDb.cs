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
        private static readonly string DatabaseName = "bookstore";

        private static string strConnect = "server=" + ServerName + ";database=" +
           DatabaseName + ";user=root;password=; pooling = false; convert zero datetime=True";


        public ConnectDb() {
          
        }

        public static int ExecuteScalar(string strQuerry)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(strConnect);
                connection.Open();
               
                MySqlCommand command = new MySqlCommand(strQuerry, connection);
                int orderId = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return orderId;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
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
