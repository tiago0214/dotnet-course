using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Request;
using CashFlow.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseJsonRegisterExpense), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseJsonError), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterExpenseUseCase useCase,
        [FromBody] RequestJsonRegisterExpense request)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseJsonExpenses), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpenseUseCase useCase)
    {
        var result = await useCase.Execute();

        if(result.Expenses.Count != 0)
            return Ok(result);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseJsonExpense), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseJsonError),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetExpenseByIdUseCase useCase,
        [FromRoute]long id) 
    {
        var result = await useCase.Execute(id);

        return Ok(result);
    }
}
