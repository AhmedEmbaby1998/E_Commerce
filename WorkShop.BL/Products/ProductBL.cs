using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilities.Enums;
using WorkShop.Model.Models.Products;
using WorkShop.Repository;
using WorkShop.Repository.RepoDtos;

namespace WorkShop.BL.Products
{
    public class ProductBL : IProductBL
    {
        private UnitOfWork UOW;

        public ProductBL(UnitOfWork uOW)
        {
            UOW = uOW;
        }

        public async Task<Product> AddProduct(Product product)
        {
            UOW.ProductRepo.AddProduct(product);
            await UOW.CommitAsync();

            return product;
        }

        public async Task<Product?> GetAProduct(long productId)
        {
            return await UOW.ProductRepo.GetProduct(productId);
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            var pr = await UOW.ProductRepo.FindProductAsync(product.Id);
            if (pr is null)
                throw new NullReferenceException();

            var count = await UOW.ProductRepo.GetProductsCount(product.NameEn, product.NameAr);
            if (count > 1)
                throw new CustomException(ErrorCodeEnum.ProductNameIsAlreadyExisted);
            product.Version++;

            pr.NameAr=product.NameEn;
            pr.NameEn = product.NameAr;
            pr.CurrentPrice = product.CurrentPrice;
            pr.CategoryId=product.CategoryId;
            pr.DescriptionAr = product.DescriptionAr;
            pr.DescriptionEn = product.DescriptionEn;
            pr.HasAvailableStock = product.HasAvailableStock;
            await UOW.CommitAsync();

            return product;
        }
        public async Task<Product> DeleteProduct(long Id)
        {
            var pr = await UOW.ProductRepo.FindProductAsync(Id);
            if (pr is null)
                throw new NullReferenceException();

            pr.Version++;
            pr.IsDeleted = true;
            pr.DeletingDate = DateTime.Now;

            await UOW.CommitAsync();

            return pr;

        }
        public async Task<(IEnumerable<Product>, int)> SearchProducts(ProductSearchModel sm)
        {
            return await UOW.ProductRepo.SearchProducts(new Repository.RepoDtos.ProductSearchModel
            {
                lang = sm.lang,
                Name = sm.Name,
                PageNumber = sm.PageNumber,
                PageSize = sm.PageSize,
                ProductCategoryId = sm.ProductCategoryId
            });
        }
    }

}
