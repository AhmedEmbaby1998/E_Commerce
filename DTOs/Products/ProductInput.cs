using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Products
{
    public class ProductInput
    {
        public long productID { get; set; }
        [Required]
        public string NameEn { set; get; }
        [Required]
        public string NameAr { set; get; }
        public string? DescriptionEn { set; get; }
        public string? DescriptionAr { set; get; }
        public bool IsAvailable { set; get; }
        public int CategoryId { set; get; }
        public double Price { get; set; }
    }
}
