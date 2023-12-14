using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class ImportDetailBus
    {
        public ImportDetailDao Dao { get; set; } = new ImportDetailDao();
       

        public List<ImportDetail> getList()
        {
            return Dao.getAll();
        }

        public ImportDetail getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(ImportDetail author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool Add(ImportDetail author)
        {
            return Dao.Add(author);
        }

    }
}
