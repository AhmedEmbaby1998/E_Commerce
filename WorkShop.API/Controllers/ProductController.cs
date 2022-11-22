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
    [Route("api/[Controller]")]
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
                    HasAvailableStock = input.IsAvailable,
                });

                return Ok();
            });
        }

        [HttpGet("GetAProduct/{productId}")]
        public async Task<IActionResult> GetAProduct([FromRoute] long productId)
        {
            return await this.TryCatchAsync(async () =>
            {
                var res = await productBL.GetAProduct(productId);
                if (res is null)
                    throw new NullReferenceException();

                return Ok(new ProductInput
                {
                    CategoryId=res.CategoryId,
                    Price=res.CurrentPrice,
                    DescriptionAr=res.DescriptionAr,
                    DescriptionEn=res.DescriptionEn,
                    IsAvailable=res.HasAvailableStock,
                    NameAr=res.NameAr,
                    NameEn=res.NameEn,
                    productID=res.Id
                });
            });
        }

        [HttpPut("updateProduct")]
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
                    HasAvailableStock = input.IsAvailable,
                    Id = input.productID
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
            return await this.TryCatchAsync((Func<Task<IActionResult>>)(async () =>
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
                    Products = data.Select(d => new ProductInputForSearch
                    {
                        CurrentPrice = d.CurrentPrice,
                        DescriptionAr = d.DescriptionAr,
                        HasAvailableStock = d.HasAvailableStock,
                        DescriptionEn = d.DescriptionEn,
                        NameAr = d.NameAr,
                        NameEn = d.NameEn
                    })
            };
                return base.Ok(returnVal);
            }));
            
        }
      

    }
}
