using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Api.Filters;

namespace ShopApp.Api.Controllers;

/*[ErrorHandlingFilterAttributes]*/

[Route("/error")]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;
        
        return Problem(statusCode: 400, title:exception?.Message);
    }
}