using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Model.Models;
using WorkShop.Model.Models.Products;

namespace WorkShop.Repository.Repos
{
    public class LookUpRepo
    {
        private WorkShopContext _context;

        public LookUpRepo(WorkShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            return await _context.ProductCategories.Where(a=>!a.IsDeleted).ToListAsync();
        }
    }
}
