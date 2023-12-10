using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class RoleBus
    {
        public RoleDao Dao { get; set; } = new RoleDao();
       

        public List<Role> getList()
        {
            return Dao.getAll();
        }

        public Role getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(Role author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool Add(Role author)
        {
            return Dao.Add(author);
        }
    }
}
