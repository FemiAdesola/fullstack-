using Backend.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController: BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponseError(code));
        }
    }
}