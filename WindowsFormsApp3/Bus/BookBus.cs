using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class BookBus
    {
        public BookDao AuthorDao { get; set; } = new BookDao();
        public BookBus() { }

        public List<Book> getList()
        {
            return AuthorDao.getAll();
        }

        public Book getFirstById(string id)
        {
            return AuthorDao.getFirstById(id);
        }
        public bool UpdateById(Book author)
        {
            return AuthorDao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return AuthorDao.DeleteById(id);
        }
        public bool Add(Book author)
        {
            return AuthorDao.Add(author);
        }
    }
}
