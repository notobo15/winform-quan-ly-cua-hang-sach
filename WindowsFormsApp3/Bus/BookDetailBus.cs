using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class BookDetailBus
    {
        public BookDetailDao Dao { get; set; } = new BookDetailDao();
        public BookDetailBus() { }

        public List<BookDetail> getList()
        {
            return Dao.getAll();
        }

        public BookDetail getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(BookDetail author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool Add(BookDetail author)
        {
            return Dao.Add(author);
        }
        public bool AvailableSell(int bookDetailId, int quantityeSell)
        {
            return Dao.AvailableSell(bookDetailId, quantityeSell);
        }
        public bool UpdateQuantitySell( int bookDetailId, int quantityeSell)
        {
            return Dao.UpdateQuantitySell(bookDetailId, quantityeSell);
        }
        public bool UpdateQuantityImport(int bookDetailId, int quantityeSell)
        {
            return Dao.UpdateQuantityImport(bookDetailId, quantityeSell);
        }

    }
}
