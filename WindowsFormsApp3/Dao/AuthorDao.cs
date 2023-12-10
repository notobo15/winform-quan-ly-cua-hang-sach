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
    public class AuthorDao
    {
        public string TableName { get; set; } = "author";
        public AuthorDao() { }
        public List<Author> getAll()
        {

            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

            List<Author> list = new List<Author>();
            foreach (DataRow row in dt.Rows)
            {
                Author tmp = new Author
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FirstName = row["FirstName"]?.ToString(),
                    LastName = row["LastName"]?.ToString(),
                    BirthDay = (DateTime)row["BirthDay"],
                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };

                list.Add(tmp);
            }
            return list;
        }

        public Author getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where  IsDeleted = 0 and id = '{id}'");
            
            Author tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                 tmp = new Author
                {
                     Id = Convert.ToInt32(row["Id"]),
                     FirstName = row["FirstName"]?.ToString(),
                     LastName = row["LastName"]?.ToString(),
                     BirthDay = (DateTime)row["BirthDay"],
                     IsDeleted = (bool)row["IsDeleted"],
                     CreatedAt = (DateTime)row["CreatedAt"],
                     UpdatedAt = (DateTime)row["UpdatedAt"],
                 };
            }
            return tmp;
        }
        public bool UpdateById(Author author)
        {
            string query = $"Update {TableName} set LastName = '{author.LastName}',FirstName = '{author.FirstName}',BirthDay = '{author.BirthDay.ToString("yyyy-MM-dd")}' where id = {author.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where Id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(Author author)
        {
            string query = $"Insert into {TableName}(FirstName, LastName, BirthDay, IsDeleted, CreatedAt, UpdatedAt) " +
                            $"VALUES ('{author.FirstName}', " +
                            $"'{author.LastName}', " +
                            $"'{author.BirthDay.ToString("yyyy-MM-dd")}', " +
                            $"'{author.IsDeleted}', " +
                            $"'{author.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'{author.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return  ConnectDb.ExecuteNonQuery(query); ;
        }
    }
}
