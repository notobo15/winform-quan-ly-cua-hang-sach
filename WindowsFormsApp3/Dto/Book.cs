using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QuanLyCuaHangSach.Dto
{
    public class Book
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public int TotalPage { get; set; }
        public string Format { get; set; }
        public int Quantity { get; set; }
        public string Language { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
