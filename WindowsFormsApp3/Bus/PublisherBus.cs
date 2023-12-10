using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class PublisherBus
    {
        public PublisherDao Dao { get; set; } = new PublisherDao();
       

        public List<Publisher> getList()
        {
            return Dao.getAll();
        }

        public Publisher getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(Publisher author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool Add(Publisher author)
        {
            return Dao.Add(author);
        }
    }
}
