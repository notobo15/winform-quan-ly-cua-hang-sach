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

        public Account Login(string username, string password)
        {
            var result = Dao.Login(username, password);
            if(result != null)
            {
                return result;
            }else
            {
                return null;
            }
        }

        public bool ResetPassword(string username, string password)
        {
            if (Dao.ResetPassword(username, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
