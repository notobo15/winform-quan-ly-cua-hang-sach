using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class AuthorBus
    {
        public AuthorDao AuthorDao { get; set; } = new AuthorDao();
        public AuthorBus() { }

        public List<Author> getList()
        {
            return AuthorDao.getAll();
        }

        public Author getFirstById(string id)
        {
            return AuthorDao.getFirstById(id);
        }
        public bool UpdateById(Author author)
        {
            return AuthorDao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return AuthorDao.DeleteById(id);
        }
        public bool Add(Author author)
        {
            return AuthorDao.Add(author);
        }
    }
}
