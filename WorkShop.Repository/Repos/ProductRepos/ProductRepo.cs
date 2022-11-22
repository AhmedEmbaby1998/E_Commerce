using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Model.Models;
using WorkShop.Model.Models.Products;
using WorkShop.Repository.RepoDtos;

namespace WorkShop.Repository.Repos.ProductRepos
{
    public class ProductRepo
    {
        private WorkShopContext _context;

        public ProductRepo(WorkShopContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public async Task<Product?> GetProduct(long productId)
        {
            return await _context.Products.FindAsync(productId);
        }
        public async Task<bool> ProductNameExistAsync(string productNameEn,string productNameAr)
        {
            return _context.Products.Any(a => a.NameEn == productNameEn || a.NameAr == productNameAr);
        }

        private Expression<Func<Product, T>> ToExpression<T>(Func<Product, T> f)
        {
            return x => f(x);
        }

        public async Task<(IEnumerable<Product>,int)> SearchProducts(ProductSearchModel sm)
        {
            var baseQuery = _context.Products.Where(ToExpression(a => (sm.ProductCategoryId == null || a.CategoryId == sm.ProductCategoryId)
            &&
            (sm.Name == null ||(sm.lang==Utilities.Enums.Lang.En&& a.NameEn == sm.Name)|| (sm.lang == Utilities.Enums.Lang.Ar && a.NameAr == sm.Name))
            ));

            var data=await baseQuery.OrderBy(ToExpression(a =>
            {
                return sm.lang is Utilities.Enums.Lang.Ar ?
                     a.NameAr : a.NameEn;
            })).Skip((sm.PageNumber - 1) * sm.PageSize).Take(sm.PageSize).ToListAsync();

            var count =await  baseQuery.CountAsync();

            return (data,count);
        }
        public async Task<int> GetProductsCount(string productNameEn, string productNameAr)
        {
            return await _context.Products.CountAsync(a => a.NameEn == productNameEn || a.NameAr == productNameAr);
        }
        public async Task<bool> ProductIdExistAsync(long Id)
        {
            return _context.Products.Any(a => a.Id==Id);
        }
        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<Product?> FindProductAsync(long productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public void AddProductCategory(ProductCategory category)
        {
            _context.ProductCategories.Add(category);
        }

        public void UpdateProductCategory(ProductCategory category)
        {
            _context.ProductCategories.Update(category);
        }

        public void DeleteProductCategory(ProductCategory category)
        {
            _context.ProductCategories.Remove(category);
        }

        public async Task<ProductCategory?> FindProductCategoryAsync(long producCategorytId)
        {
            return await _context.ProductCategories.FindAsync(producCategorytId);
        }
    }
}
