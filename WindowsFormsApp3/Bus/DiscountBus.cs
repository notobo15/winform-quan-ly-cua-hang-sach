using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class DiscountBus
    {
        public DiscountDao Dao { get; set; } = new DiscountDao();
       

        public List<Discount> getList()
        {
            return Dao.getAll();
        }

        public Discount getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(Discount author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool Add(Discount author)
        {
            return Dao.Add(author);
        }
    }
}
