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
    public class CategoryDao
    {
        public string TableName { get; set; } = "category";
        public CategoryDao() { }
        public List<Category> getAll()
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

            List<Category> list = new List<Category>();

            foreach (DataRow row in dt.Rows)
            {
                Category tmp = new Category
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = (string)row["Name"],
                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };

                list.Add(tmp);
            }
            return list;
        }

        public Category getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");

            Category tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new Category
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    IsDeleted = (bool)row["IsDeleted"],
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
        public bool UpdateById(Category category)
        {
            category.UpdatedAt = DateTime.Now;
            string query = $"UPDATE {TableName} SET " +
                $"`Name` = '{category.Name}', " +
                $"UpdatedAt = '{Utils.Util.FormatDateTime(category?.UpdatedAt)}' " +
                $"where IsDeleted = 0 and Id = {category.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(Category  category)
        {
            category.IsDeleted = false;
            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}(Name, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES ('{category.Name}', " +
                            $"'{category.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{category.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query); ;
        }
    }
}
