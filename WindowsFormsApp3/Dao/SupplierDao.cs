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
    public class SupplierDao : ICrudDao<Supplier>
    {
        public string TableName { get; set; } = "supplier";
        public SupplierDao() { }
        public List<Supplier> getAll()
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

            var list = new List<Supplier>();

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new Supplier
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = Convert.ToString(row["Name"]),
                    Phone = Convert.ToString(row["Phone"]),
                    Address = Convert.ToString(row["Address"]),
                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                };

                list.Add(tmp);
            }
            return list;
        }

        public Supplier getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0 and id = '{id}'");

            Supplier tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new Supplier
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = Convert.ToString(row["Name"]),
                    Phone = Convert.ToString(row["Phone"]),
                    Address = Convert.ToString(row["Address"]),
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
        public bool UpdateById(Supplier supplier)
        {
            string query = $"UPDATE {TableName} SET " +
                $"`Name` = '{supplier.Name}', " +
                $"`Phone` = '{supplier.Phone}', " +
                $"`Address` = '{supplier.Address}', " +
                $"UpdatedAt = '{Utils.Util.FormatDateTime(supplier?.UpdatedAt)}' " +
                $"where IsDeleted = 0 and Id = {supplier?.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(Supplier supplier)
        {
            supplier.IsDeleted = false;
            supplier.CreatedAt = DateTime.Now;
            supplier.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}(Name, Phone, Address, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES ('{supplier.Name}', " +
                            $"'{supplier.Phone}', " +
                            $"'{supplier.Address}', " +
                            $"'{supplier.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{supplier.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query); ;
        }
    }
}
