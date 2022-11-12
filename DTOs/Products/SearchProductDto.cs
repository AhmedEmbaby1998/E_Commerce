using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Products
{
    public class SearchProductDto
    {
        public int Count { set; get; }
        public IEnumerable<ProductDto> Products { get; set; }

    }

    public class ProductDto
    {
        public string NameEn { set; get; }
        public string NameAr { set; get; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { set; get; }
        public double CurrentPrice { set; get; }
        public bool HasAvailableStock { set; get; }


    }
}
