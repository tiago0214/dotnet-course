using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;

public class DevicesController : MyFirstApiBaseController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
