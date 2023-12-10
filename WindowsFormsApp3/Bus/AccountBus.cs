using QuanLyCuaHangSach.Dao;
using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Bus
{
    public class AccountBus
    {
        public AccountDao Dao { get; set; } = new AccountDao();
        public AccountBus() { }

        public List<Account> getList()
        {
            return Dao.getAll();
        }

        public Account getFirstById(string id)
        {
            return Dao.getFirstById(id);
        }
        public bool UpdateById(Account author)
        {
            return Dao.UpdateById(author);
        }
        public bool DeleteById(string id)
        {
            return Dao.DeleteById(id);
        }
        public bool Add(Account author)
        {
            return Dao.Add(author);
        }

        public bool Login(string username, string password)
        {
            if(Dao.Login(username, password) != null)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
