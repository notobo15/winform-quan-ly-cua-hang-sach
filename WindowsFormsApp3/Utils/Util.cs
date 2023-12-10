using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Utils
{
    public class Util
    {
        public static string FormatDateTime(DateTime? date)
        {
            if (date == null)
                return "";
            return date?.ToString("yyyy-MM-dd HH:mm:ss");
        } 
    }
}
