using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Dto
{
    public class BookDetail
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
