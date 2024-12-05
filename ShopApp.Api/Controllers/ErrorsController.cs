using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ShopApp.Api.Controllers;

/*[ErrorHandlingFilterAttributes]*/
[ApiController]
[Route("/error")]
public class ErrorsController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;
        
        return Problem(statusCode: 400, title:exception?.Message);
    }
}