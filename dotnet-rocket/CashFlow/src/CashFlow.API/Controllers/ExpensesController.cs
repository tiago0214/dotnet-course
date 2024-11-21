﻿using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Request;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestJsonRegisterExpense request)
    {
        var useCase = new RegisterExpenseUseCase().Execute(request);

        return Created(string.Empty, useCase);
    }
}
