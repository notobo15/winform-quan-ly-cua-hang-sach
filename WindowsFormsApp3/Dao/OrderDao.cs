using QuanLyCuaHangSach.Configs;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.Gui.Forms;

namespace QuanLyCuaHangSach.Dao
{
    public class OrderDao : ICrudDao<Order>
    {
        public string TableName { get; set; } = "orders";

        public List<Order> getAll()
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

            var list = new List<Order>();

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new Order
                {
                    Id = Convert.ToInt32(row["Id"]),
                    AccountId = Convert.ToInt32(row["AccountId"]),
                    Status = row["Status"].ToString(),
                    CustomerId = Convert.ToInt32(row["CustomerId"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                };

                list.Add(tmp);
            }
            return list;
        }

        public Order getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");

            Order tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new Order
                {
                    Id = Convert.ToInt32(row["Id"]),
                    AccountId = Convert.ToInt32(row["AccountId"]),
                    Status = row["Status"].ToString(),
                    CustomerId = Convert.ToInt32(row["CustomerId"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                };
            }
            return tmp;
        }

        public bool existsById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateById(Order role)
        {
            string query = $"UPDATE {TableName} SET " +
                $"`AccountId` = '{role.AccountId}', " +
                $"UpdatedAt = '{Utils.Util.FormatDateTime(role?.UpdatedAt)}' " +
                $"where IsDeleted = 0 and Id = {role.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }
        public bool DeleteHardById(int id)
        {
            string strQuery = $" DELETE FROM {TableName}  where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }
        public bool Add(Order role)
        {
            role.IsDeleted = false;
            role.CreatedAt = DateTime.Now;
            role.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}( Status, AccountId, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES ('{role.Status}', " +
                            $"'{role.AccountId}', " +
                            $"'{role.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{role.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query);
        }
        public int CreateOrder(Order role) //
        {
            role.IsDeleted = false;
            role.CreatedAt = DateTime.Now;
            role.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}( Status, AccountId,CustomerId, OrderDate, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES ('{role.Status}', " +
                            $"'{role.AccountId}', " +
                            $"'{role.CustomerId}', " +
                            $"'{role.OrderDate.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'{role.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{role.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}'); SELECT LAST_INSERT_ID();";
            return ConnectDb.ExecuteScalar(query);
        }
        public int CreateOrderWithoutCustomer(Order role) //
        {
            role.IsDeleted = false;
            role.CreatedAt = DateTime.Now;
            role.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}( Status, AccountId, OrderDate, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES ('{role.Status}', " +
                            $"'{role.AccountId}', " +
                            $"'{role.OrderDate.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'{role.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{role.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}'); SELECT LAST_INSERT_ID();";
            return ConnectDb.ExecuteScalar(query);
        }

        public bool UpdateStatusSuccess(int orderId)
        {
            string strQuery = $"UPDATE {TableName} set Status = 'Thành Công' where id='{orderId}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public List<FOrder.CustomBook> getListOrder(string orderId)
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($@"
                            SELECT  T4.Id AS BooId, T2.Price, T2.BuyQuantity, T3.Barcode, T4.Name
                            FROM orders T1 
                            JOIN orderdetail T2 ON T1.Id = T2.OrderId
                            JOIN bookdetail T3 ON T3.Id = T2.BookDetailId
                            JOIN book T4 ON T4.Id = T3.BookId
                            WHERE T1.Id = '{orderId}'
                    ");

            var list = new List<FOrder.CustomBook>();

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new FOrder.CustomBook
                {
                    BookId = Convert.ToInt32(row["BooId"]),
                    Price = Convert.ToDouble(row["Price"]),
                    Quantity = Convert.ToInt32(row["BuyQuantity"]),
                    Barcode = (row["Barcode"].ToString()),
                    Name = (row["Name"].ToString()),
                };
                tmp.SetTotalCost();

                list.Add(tmp);
            }
            return list;
        }
    }
}
