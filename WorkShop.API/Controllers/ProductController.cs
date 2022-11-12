using DTOs.Products;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using Utilities;
using Utilities.Enums;
using WorkShop.BL.Products;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WorkShop.API.Controllers
{
    [ApiController]
    [Route("api/Controller")]
    public class ProductController : BaseController
    {
        private IProductBL productBL;
        public ProductController(IProductBL _productBL)
        {
            this.productBL = _productBL;
        }
        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductInput input)
        {
            return await this.TryCatchAsync(async () =>
            {
                var res = await productBL.AddProduct(new Model.Models.Products.Product
                {
                    CategoryId = input.CategoryId,
                    DescriptionAr = input.DescriptionAr,
                    NameEn = input.NameEn,
                    DescriptionEn = input.DescriptionEn,
                    CurrentPrice = input.Price,
                    NameAr = input.NameAr,
                    HasAvailableStock = input.IsAvailable
                });

                return Ok();
            });
        }

        [HttpPost("updateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductInput input)
        {
            return await this.TryCatchAsync(async () =>
            {
                var res = await productBL.UpdateProduct(new Model.Models.Products.Product
                {
                    CategoryId = input.CategoryId,
                    DescriptionAr = input.DescriptionAr,
                    NameEn = input.NameEn,
                    DescriptionEn = input.DescriptionEn,
                    CurrentPrice = input.Price,
                    NameAr = input.NameAr,
                    HasAvailableStock = input.IsAvailable
                });

                return Ok();
            });
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromQuery] long Id)
        {
            return
                await this.TryCatchAsync(async () =>
                {
                    await productBL.DeleteProduct(Id);
                    return Ok();
                });


        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromBody] ProductSearchModelDto sm)
        {
            return await this.TryCatchAsync(async () =>
            {
                (var data, var count) = await productBL.SearchProducts(new Repository.RepoDtos.ProductSearchModel
                {
                    lang = sm.lang,
                    Name = sm.Name,
                    ProductCategoryId = sm.ProductCategoryId,
                    PageNumber = sm.PageNumber,
                    PageSize = sm.PageSize
                });
                var returnVal = new SearchProductDto
                {
                    Count = count,
                    Products = data.Select(d => new ProductDto
                    {
                        CurrentPrice = d.CurrentPrice,
                        DescriptionAr = d.DescriptionAr,
                        HasAvailableStock = d.HasAvailableStock,
                        DescriptionEn = d.DescriptionEn,
                        NameAr = d.NameAr,
                        NameEn = d.NameEn
                    })
            };
                return Ok(returnVal);
            });
            
        }
      

    }
}
