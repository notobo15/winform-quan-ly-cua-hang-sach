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
    public class PublisherDao : ICrudDao<Publisher>
    {
        public string TableName { get; set; } = "publisher";
        public PublisherDao() { }
        public List<Publisher> getAll()
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

            var list = new List<Publisher>();

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new Publisher
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"]?.ToString(),
                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };

                list.Add(tmp);
            }
            return list;
        }

        public Publisher getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");

            Publisher tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new Publisher
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"]?.ToString(),
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
        public bool UpdateById(Publisher publisher)
        {
            string query = $"UPDATE {TableName} SET " +
                $"`Name` = '{publisher.Name}', " +
                $"UpdatedAt = '{Utils.Util.FormatDateTime(publisher?.UpdatedAt)}' " +
                $"where IsDeleted = 0 and Id = {publisher?.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(Publisher publisher)
        {
            publisher.IsDeleted = false;
            publisher.CreatedAt = DateTime.Now;
            publisher.UpdatedAt = DateTime.Now;
            string query = $"Insert into {TableName}(Name, CreatedAt, IsDeleted, UpdatedAt) " +
                            $"VALUES ('{publisher.Name}', " +
                            $"'{publisher.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'0', " +
                            $"'{publisher.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query); ;
        }
    }
}
