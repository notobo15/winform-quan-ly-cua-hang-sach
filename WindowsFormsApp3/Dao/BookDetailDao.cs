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
    public class BookDetailDao
    {
        public string TableName { get; set; } = "bookdetail";
        public BookDetailDao() { }
        public List<BookDetail> getAll()
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where IsDeleted = 0;");

            var list = new List<BookDetail>();
            foreach (DataRow row in dt.Rows)
            {
                var tmp = new BookDetail
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Barcode = row["Barcode"]?.ToString(),
                    Price = Convert.ToDouble(row["Barcode"]),

                    BookId = Convert.ToInt32(row["BookId"]),
                    SupplierId = Convert.ToInt32(row["SupplierId"]),

                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };

                list.Add(tmp);
            }
            return list;
        }

        public BookDetail getFirstById(string id)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($"select * from {TableName} where id = '{id}'");

            BookDetail tmp = null;
            foreach (DataRow row in dt.Rows)
            {
                tmp = new BookDetail
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Barcode = row["Barcode"]?.ToString(),
                    Price = Convert.ToDouble(row["Barcode"]),

                    BookId = Convert.ToInt32(row["BookId"]),
                    SupplierId = Convert.ToInt32(row["SupplierId"]),

                    IsDeleted = (bool)row["IsDeleted"],
                    CreatedAt = (DateTime)row["CreatedAt"],
                    UpdatedAt = (DateTime)row["UpdatedAt"],
                };
            }
            return tmp;
        }
        public bool UpdateById(BookDetail bookDetail)
        {
            string query = $"Update {TableName} set" +
                $" Barcode = '{bookDetail.Barcode}'," +
                $"BookId = '{bookDetail.BookId}'," +
                $"SupplierId = '{bookDetail.SupplierId}'" +
                $" where id = {bookDetail.Id}";
            return ConnectDb.ExecuteNonQuery(query);
        }

        public bool DeleteById(string id)
        {
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where TenTaiKhoan='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool Add(BookDetail book)
        {
            string query = $"Insert into {TableName}(Barcode, Price, BookId,SupplierId, IsDeleted, CreatedAt, UpdatedAt) " +
                            $"VALUES ('{book.Barcode}', " +
                            $"'{book.Price}', " +
                            $"'{book.BookId}', " +
                            $"'{book.SupplierId}', " +
                            $"'0', " +
                            $"'{book.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"'{book.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return ConnectDb.ExecuteNonQuery(query); ;
        }
    }
}
