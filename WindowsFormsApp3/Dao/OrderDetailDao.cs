using QuanLyCuaHangSach.Configs;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Dao
{
    public class OrderDetailDao : ICrudDao<OrderDetail>
    {
        public string TableName { get; set; } = "orderdetail";
        public OrderDetailDao() { }
        public List<OrderDetail> getAll()
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

            var list = new List<OrderDetail>();

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new OrderDetail
                {
                    Id = Convert.ToInt32(row["Id"]),
                    OrderId = Convert.ToInt32(row["OrderId"]),
                    BookDetailId = Convert.ToInt32(row["BookDetailId"]),
                    Price = Convert.ToDouble(row["Price"]),
                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                };

                list.Add(tmp);
            }
            return list;
        }

        public OrderDetail getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");

            OrderDetail tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new OrderDetail
                {
                    Id = (int)row["Id"],
                   // Name = row["Name"].ToString(),
                  //  IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
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
        public bool UpdateById(OrderDetail role)
        {
            string query = $"UPDATE {TableName} SET " +
                $"`Name` = '{role.BuyQuantity}', " +
                $"UpdatedAt = '{Utils.Util.FormatDateTime(role?.UpdatedAt)}' " +
                $"where IsDeleted = 0 and Id = {role.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(OrderDetail orderDetail)
        {
            orderDetail.CreatedAt = DateTime.Now;
            orderDetail.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}(OrderId,BookDetailId, Price, BuyQuantity, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES (" +
                            $"'{orderDetail.OrderId}', " +
                            $"'{orderDetail.BookDetailId}', " +
                            $"'{orderDetail.Price}', " +
                            $"'{orderDetail.BuyQuantity}', " +
                            $"'{orderDetail.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{orderDetail.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query);
        }
    }
}
