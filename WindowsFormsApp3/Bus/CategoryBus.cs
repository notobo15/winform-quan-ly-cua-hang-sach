using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class CategoryBus
    {
        public CategoryDao Dao { get; set; } = new CategoryDao();
        public CategoryBus() { }

        public List<Category> getList()
        {
            return Dao.getAll();
        }

        public Category getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(Category author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool Add(Category author)
        {
            return Dao.Add(author);
        }
    }
}
