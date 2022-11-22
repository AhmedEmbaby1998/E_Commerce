using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Model.Models.Products;
using WorkShop.Repository;

namespace WorkShop.BL
{
    public class LookUpService: ILookUpService
    {
        private UnitOfWork UOW;

        public LookUpService(UnitOfWork uOW)
        {
            UOW = uOW;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategory()
        {
            return await UOW.LookUpRepo.GetProductCategories();
        }
    }
}
