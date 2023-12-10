using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class SupplierBus
    {
        public SupplierDao Dao { get; set; } = new SupplierDao();
       

        public List<Supplier> getList()
        {
            return Dao.getAll();
        }

        public Supplier getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(Supplier author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool Add(Supplier author)
        {
            return Dao.Add(author);
        }
    }
}
