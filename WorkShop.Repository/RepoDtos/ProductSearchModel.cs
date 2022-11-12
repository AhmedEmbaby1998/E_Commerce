using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;

namespace WorkShop.Repository.RepoDtos
{
    public class ProductSearchModel
    {
        public string? Name { set; get; }
        public Lang lang { set; get; }
        public int? ProductCategoryId { set; get; }
        public int PageNumber { set; get; }
        public int PageSize { set; get; }

    }
}
