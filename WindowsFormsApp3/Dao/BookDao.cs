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
    public class BookDao
    {
        public string TableName { get; set; } = "book";
        public BookDao() { }
        public List<Book> getAll()
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

            List<Book> list = new List<Book>();
            foreach (DataRow row in dt.Rows)
            {
                Book tmp = new Book
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"]?.ToString(),
                    Image = row["Image"]?.ToString(),
                    Description = row["Description"]?.ToString(),
                    PublicationDate = (DateTime)row["PublicationDate"],
                    TotalPage = (int)row["TotalPage"],
                    Format = row["Format"]?.ToString(),
                    Quantity = row["Quantity"]?.ToString(),
                    Language = row["Language"]?.ToString(),
                  
                    CategoryId = (int)row["CategoryId"],
                    PublisherId = (int)row["PublisherId"],
                    AuthorId = (int)row["AuthorId"],

                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };

                list.Add(tmp);
            }
            return list;
        }

        public Book getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0 and id = '{id}'");

            Book tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new Book
                {
                    Id = (int)row["Id"],
                    Name = row["Name"]?.ToString(),
                    Image = row["Image"]?.ToString(),
                    Description = row["Description"]?.ToString(),
                    PublicationDate = (DateTime)row["PublicationDate"],
                    TotalPage = (int)row["TotalPage"],
                    Format = row["Format"]?.ToString(),
                    Quantity = row["Quantity"]?.ToString(),
                    Language = row["Language"]?.ToString(),

                    CategoryId = (int)row["CategoryId"],
                    PublisherId = (int)row["PublisherId"],
                    AuthorId = (int)row["AuthorId"],

                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };
            }
            return tmp;
        }
        public bool UpdateById(Book b)
        {
            string query = $"Update {TableName} set " +
                $"Name = '{b.Name}'," +
                $"Image = '{b.Image}'," +
                $"Description = '{b.Description}'," +
                $"TotalPage = '{b.TotalPage}'," +
                $"Format = '{b.Format}'," +
                $"Quantity = '{b.Quantity}'," +
                $"Language = '{b.Language}'," +
                $"CategoryId = '{b.CategoryId}'," +
                $"PublisherId = '{b.PublisherId}'," +
                $"AuthorId = '{b.AuthorId}'," +
                $"BirthDay = '{b.PublicationDate.ToString("yyyy-MM-dd")}'" +
                $" where id = {b.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(Book book)
        {
            string query = $"Insert into {TableName}(Name,Image, Description,TotalPage, Format,Quantity,Language,CategoryId,PublisherId,AuthorId, PublicationDate, IsDeleted, CreatedAt, UpdatedAt) " +
                            $"VALUES ('{book.Name}', " +
                            $"'{book.Image}', " +
                            $"'{book.Description}', " +
                            $"'{book.TotalPage}', " +
                            $"'{book.Format}', " +
                            $"'{book.Quantity}', " +
                            $"'{book.Language}', " +
                            $"'{book.CategoryId}', " +
                            $"'{book.PublisherId}', " +
                            $"'{book.AuthorId}', " +
                            $"'{book.PublicationDate.ToString("yyyy-MM-dd")}', " +
                            $"'{book.IsDeleted}', " +
                            $"'{book.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'{book.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query);
        }
    }
}
