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
    public class CustomerDao : ICrudDao<Customer>
    {
        public string TableName { get; set; } = "customer";
        public CustomerDao() { }
        public List<Customer> getAll()
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

           var list = new List<Customer>();

            foreach (DataRow row in dt.Rows)
            {
                Customer tmp = new Customer
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"]?.ToString(),
                    Phone = row["Phone"]?.ToString(),
                    Address = row["Address"]?.ToString(),
                    Gender = Convert.ToInt32(row["Gender"]),
                    BirthDay = Convert.ToDateTime(row["BirthDay"]),
                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                };

                list.Add(tmp);
            }
            return list;
        }

        public Customer getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");

            Customer tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new Customer
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"]?.ToString(),
                    Phone = row["Phone"]?.ToString(),
                    Address = row["Address"]?.ToString(),
                    Gender = Convert.ToInt32(row["Gender"]),
                    BirthDay = Convert.ToDateTime(row["BirthDay"]),
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
        public bool UpdateById(Customer customer)
        {
            string query = $"UPDATE {TableName} SET " +
                $"`Name` = '{customer.Name}', " +
                $"`Phone` = '{customer.Phone}', " +
                $"`Gender` = '{customer.Gender}', " +
                $"`Address` = '{customer.Address}', " +
                $"`BirthDay` = '{Utils.Util.FormatDateTime(customer?.BirthDay)}', " +
                $"UpdatedAt = '{Utils.Util.FormatDateTime(customer?.UpdatedAt)}' " +
                $"where IsDeleted = 0 and Id = {customer.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(Customer customer)
        {
            customer.IsDeleted = false;
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}(Name,Phone,Gender,Address,BirthDay,  CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES ('{customer.Name}', " +
                            $"'{customer.Phone}', " +
                            $"'{customer.Gender}', " +
                            $"'{customer.Address}', " +
                            $"'{customer.BirthDay.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'{customer.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{customer.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query); ;
        }
    }
}
