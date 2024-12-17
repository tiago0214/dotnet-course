using CashFlow.Communication.Response;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        Console.WriteLine(context.Exception.Message);

        if(context.Exception is CashFlowException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnkownError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var cashFlowException = (CashFlowException)context.Exception;

        context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;

        var errorResponse = new ResponseJsonError(cashFlowException.GetErrors());

        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnkownError(ExceptionContext context) 
    {
        var errorResponse = new ResponseJsonError(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Result = new ObjectResult(errorResponse);
    }
}
