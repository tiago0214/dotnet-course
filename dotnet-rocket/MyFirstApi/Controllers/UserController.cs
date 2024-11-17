using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Cummunication.Requests;
using MyFirstApi.Cummunication.Response;

namespace MyFirstApi.Controllers;

public class UserController : MyFirstApiBaseController
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(User), StatusCodes.Status400BadRequest)]
    public IActionResult GetById([FromRoute] int id)
    {
        var response = new User
        {
            Age = 30,
            Name = "Tiago"
        };

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RequestUserRegister), StatusCodes.Status201Created)]
    public IActionResult CreateUser([FromBody] RequestUserRegister request) 
    {
        var response = new ResponseUserRegister
        {
            Id = 123,
            Name = request.Name,
        };

        return Created(string.Empty, response);
    }


    [HttpPut]
    [ProducesResponseType(typeof(RequestUserRegister), StatusCodes.Status204NoContent)]
    public IActionResult Update([FromBody] RequestUserUpdate request)
    {
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete() 
    { 
        return NoContent(); 
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public IActionResult GetAll() 
    { 
        var response = new List<User>()
        {
            new User(){Id = 1, Name = "Tiago", Age = 30},
            new User(){Id = 2, Name = "Shara", Age = 28}
        };

        return Ok(response);
    }

    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult ChangePassword([FromBody] RequestUserChangePassword request)
    {
        return NoContent();
    }
}
