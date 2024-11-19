using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pet.GetAll;
using Petfolio.Application.UseCases.Pet.GetById;
using Petfolio.Application.UseCases.Pet.Register;
using Petfolio.Application.UseCases.Pet.Update;
using Petfolio.Communication.Request;
using Petfolio.Communication.Response;

namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponsePetRegisterJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestPet request)
    {
        var response = new RegisterPetUseCase().Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestPet request)
    {
        var useCase = new UpdatePetUseCase();
        useCase.Execute(id, request);
        
        return Created();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllPetUseCase();

        var response = useCase.Execute();

        if(response.Pets.Any())
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson),StatusCodes.Status404NotFound)]
    public IActionResult Get(int id) 
    {
        var useCase = new GetByIdUseCase();

        var response = useCase.Execute(id);

        return Ok(response);
    }
}
