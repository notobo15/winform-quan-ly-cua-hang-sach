using QuanLyCuaHangSach.Configs;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    Barcode = Convert.ToString(row["Barcode"]),
                    BookId = Convert.ToInt32(row["BookId"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    SupplierId = row["SupplierId"] != DBNull.Value ? Convert.ToInt32(row["SupplierId"]) : 0,
                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
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
                    Barcode = Convert.ToString(row["Barcode"]),
                    BookId = Convert.ToInt32(row["BookId"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    SupplierId = row["SupplierId"] != DBNull.Value ? Convert.ToInt32(row["SupplierId"]) : 0,
                    IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
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
            string strQuery = $"UPDATE {TableName} set IsDeleted = 1 where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }

        public bool  UpdateQuantitySell(int id, int quantity)
        {
            string strQuery = $"UPDATE {TableName} set Quantity = Quantity - {quantity} where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }
        public bool UpdateQuantityImport(int id, int quantity)
        {
            string strQuery = $"UPDATE {TableName} set Quantity = Quantity + {quantity} where id='{id}'";

            return ConnectDb.ExecuteNonQuery(strQuery);
        }
        public bool Add(BookDetail book)
        {
            book.CreatedAt = DateTime.Now;
            book.UpdatedAt = DateTime.Now;
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
        public bool AvailableSell(int bookDetailId, int quantitySell)
        {
            DataTable dt = ConnectDb.ExecuteReaderTable($@"
                        SELECT bookdetail.BookId,
                       book.Name AS book_title,
                       bookdetail.quantity AS available_quantity
                        FROM bookdetail
                        JOIN book ON book.id = bookdetail.BookId
                        WHERE bookdetail.BookId = {bookDetailId}
                        HAVING available_quantity >= {quantitySell};
            ");
          
            return dt.Rows.Count > 0;
        }
    }
}
