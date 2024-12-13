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
        if (context.Exception is ErrorOnValidationException)
        {
            ErrorOnValidationException ex = (ErrorOnValidationException)context.Exception;

            var errorResponse = new ResponseJsonError(ex.Errors);

            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else
        {
            var errorResponse = new ResponseJsonError(context.Exception.Message);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }

    private void ThrowUnkownError(ExceptionContext context) 
    {
        var errorResponse = new ResponseJsonError(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Result = new ObjectResult(errorResponse);
    }
}
