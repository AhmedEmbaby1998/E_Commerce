using WorkShop.Model.Models.Products;
using WorkShop.Repository.RepoDtos;

namespace WorkShop.BL.Products
{
    public interface IProductBL
    {
        Task<Product> AddProduct(Product product);
        Task<Product> DeleteProduct(long Id);
        Task<(IEnumerable<Product>, int)> SearchProducts(ProductSearchModel sm);
        Task<Product> UpdateProduct(Product product);
        Task<Product?> GetAProduct(long productId);
    }
}