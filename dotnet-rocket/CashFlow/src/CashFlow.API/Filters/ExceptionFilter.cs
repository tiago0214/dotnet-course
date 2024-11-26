using CashFlow.Communication.Response;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
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
        if(context.Exception is ErrorOnValidationException)
        {
            ErrorOnValidationException ex = (ErrorOnValidationException)context.Exception;

            var errorResponse = new ResponseJsonError(ex.Errors);

            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }

    private void ThrowUnkownError(ExceptionContext context) 
    {
        var errorResponse = new ResponseJsonError("Unknown error");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Result = new ObjectResult(errorResponse);
    }
}
