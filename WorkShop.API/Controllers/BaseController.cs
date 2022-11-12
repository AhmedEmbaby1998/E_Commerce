using Microsoft.AspNetCore.Mvc;
using Utilities;
using Utilities.Enums;

namespace WorkShop.API.Controllers
{
    public class BaseController:ControllerBase
    {
        protected async Task<IActionResult> TryCatchAsync(Func<Task<IActionResult>> func)
        {
            try
            {
                return await func();
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.ErrorCode);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorCodeEnum.ServerError);
            }
        }
    }
}
