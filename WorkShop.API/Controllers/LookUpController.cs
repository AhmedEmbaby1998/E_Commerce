using Microsoft.AspNetCore.Mvc;
using WorkShop.BL;
using WorkShop.BL.Products;

namespace WorkShop.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LookUpController:BaseController
    {
        private ILookUpService _lookUpBL;
        public LookUpController(ILookUpService lookUpBL)
        {
            this._lookUpBL = lookUpBL;
        }

        [HttpGet("getProductCategories")]
        public async Task<IActionResult> GetProductCategories()
        {
            return await this.TryCatchAsync(async () =>
            {
                return Ok(await _lookUpBL.GetProductCategory());
            });
        }
    }
}
