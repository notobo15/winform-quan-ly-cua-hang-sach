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
    public class ImportBus
    {
        public ImportDao Dao { get; set; } = new ImportDao();
       

        public List<Import> getList()
        {
            return Dao.getAll();
        }

        public Import getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(Import author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool Add(Import author)
        {
            return Dao.Add(author);
        }
        public int CreateImport(Import author)
        {
            return Dao.CreateImport(author);
        }
        public bool DeleteHardById(int id)
        {
            return Dao.DeleteHardById(id);
        }
        public List<FOrder.CustomBook> getListOrder(string orderId)
        {
            return Dao.getListOrder(orderId);
        }
    }
}
