using QuanLyCuaHangSach.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Dao
{
    public interface ICrudDao<T>
    {
         List<T> getAll();
         T getFirstById(string id);
         bool existsById(string id);
         bool UpdateById(T category);
         bool DeleteById(string id);
    }
}
