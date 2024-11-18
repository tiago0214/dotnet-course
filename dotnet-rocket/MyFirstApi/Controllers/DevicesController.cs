using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Entities;

namespace MyFirstApi.Controllers;

public class DevicesController : MyFirstApiBaseController
{
    [HttpGet]
    public IActionResult Get([FromHeader] string name)
    {
        var header = Request.Headers["name"];

        var laptop = new Laptop();

        var model = laptop.GetBrand();

        return Ok(model);
    }
}
