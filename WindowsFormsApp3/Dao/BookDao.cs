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
                    PublicationDate = Convert.ToDateTime( row["PublicationDate"]),
                    TotalPage = Convert.ToInt32( row["TotalPage"]),
                    Format = row["Format"]?.ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Language = row["Language"]?.ToString(),
                    Price = Convert.ToDouble(row["Price"]),
                    CategoryId =Convert.ToInt32( row["CategoryId"]),
                    PublisherId = Convert.ToInt32(row["PublisherId"]),
                    AuthorId = Convert.ToInt32(row["AuthorId"]),
                    DiscountId = Convert.ToInt32(row["DiscountId"]),

                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
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
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"]?.ToString(),
                    Image = row["Image"]?.ToString(),
                    Description = row["Description"]?.ToString(),
                    PublicationDate = Convert.ToDateTime(row["PublicationDate"]),
                    TotalPage = Convert.ToInt32(row["TotalPage"]),
                    Format = row["Format"]?.ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Language = row["Language"]?.ToString(),
                    Price = Convert.ToDouble(row["Price"]),
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    PublisherId = Convert.ToInt32(row["PublisherId"]),
                    AuthorId = Convert.ToInt32(row["AuthorId"]),
                    DiscountId = Convert.ToInt32(row["DiscountId"]),
                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                };
            }
            return tmp;
        }
        public bool UpdateById(Book b)
        {
            string query = $"Update {TableName} set " +
                $"Name = '{b.Name}'," +
                $"Price = '{b.Price}'," +
                $"Image = '{b.Image}'," +
                $"TotalPage = '{b.TotalPage}'," +
                $"Format = '{b.Format}'," +
                $"Quantity = '{b.Quantity}'," +
                $"Language = '{b.Language}'," +
                $"CategoryId = '{b.CategoryId}'," +
                $"PublisherId = '{b.PublisherId}'," +
                $"AuthorId = '{b.AuthorId}'," +
                $"DiscountId = '{b.DiscountId}'," +
                $"PublicationDate = '{b.PublicationDate.ToString("yyyy-MM-dd")}'" +
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
            string query = $"Insert into {TableName}(Name,Image, Price,TotalPage, Format,Quantity,Language,CategoryId,PublisherId,AuthorId,DiscountId, PublicationDate, IsDeleted, CreatedAt, UpdatedAt) " +
                            $"VALUES ('{book.Name}', " +
                            $"'{book.Image}', " +
                            $"'{book.Price}', " +
                            $"'{book.TotalPage}', " +
                            $"'{book.Format}', " +
                            $"'{book.Quantity}', " +
                            $"'{book.Language}', " +
                            $"'{book.CategoryId}', " +
                            $"'{book.PublisherId}', " +
                            $"'{book.AuthorId}', " +
                            $"'{book.DiscountId}', " +
                            $"'{book.PublicationDate.ToString("yyyy-MM-dd")}', " +
                            $"'0', " +
                            $"'{book.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'{book.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query);
        }
    }
}
