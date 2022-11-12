using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Model.Models;
using WorkShop.Repository.Repos.ProductRepos;

namespace WorkShop.Repository
{
    public class UnitOfWork
    {
        private WorkShopContext _context;
        public ProductRepo ProductRepo {private set; get; }

        public UnitOfWork(WorkShopContext context)
        {
            _context = context;
            ProductRepo = new ProductRepo(_context);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
