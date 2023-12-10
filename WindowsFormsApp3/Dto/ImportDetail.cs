using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangSach.Dto
{
    internal class ImportDetail
    {
        public int Id { get; set; }
        public int ImportId { get; set; }
        public Import Import { get; set; }
        public int BookDetailId { get; set; }
        public BookDetail BookDetail { get; set; }
        public double Price { get; set; }
        public int BuyQuantity { get; set; }
        public bool IsdDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
