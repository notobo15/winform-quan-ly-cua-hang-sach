using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class OrderDetailBus
    {
        public OrderDetailDao  Dao { get; set; } = new OrderDetailDao();
       

        public List<OrderDetail> getList()
        {
            return Dao.getAll();
        }

        public OrderDetail getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(OrderDetail author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool Add(OrderDetail author)
        {
            return Dao.Add(author);
        }
    }
}
