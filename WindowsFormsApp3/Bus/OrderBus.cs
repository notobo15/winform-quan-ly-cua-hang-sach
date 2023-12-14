using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.Gui.Forms;

namespace QuanLyCuaHangSach.Bus
{
    public class OrderBus
    {
        public OrderDao  Dao { get; set; } = new OrderDao();
       

        public List<Order> getList()
        {
            return Dao.getAll();
        }

        public Order getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(Order author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool DeleteHardById(int id)
        {
            return Dao.DeleteHardById(id);
        }
        public bool Add(Order author)
        {
            return Dao.Add(author);
        }
        public int CreateOrder(Order author)
        {
            return Dao.CreateOrder(author);
        }
        
         public int CreateOrderWithoutCustomer(Order author)
                {
                    return Dao.CreateOrderWithoutCustomer(author);
                }

        public bool UpdateStatusSuccess(int orderId)
        {
            return Dao.UpdateStatusSuccess(orderId);
        }
        public List<FOrder.CustomBook> getListOrder(string orderId)
        {
            return Dao.getListOrder(orderId);
        }
    }
}
