using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Dto
{
    internal class Import
    {
        public int Id { get; set; }
        public DateTime ImportDate { get; set; }
        //  public Supplier Supplier { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
        public bool IsdDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
