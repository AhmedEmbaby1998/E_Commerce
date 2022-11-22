using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Model.Models.Products;

namespace WorkShop.BL
{
    public interface ILookUpService
    {
          Task<IEnumerable<ProductCategory>> GetProductCategory();
    }
}
