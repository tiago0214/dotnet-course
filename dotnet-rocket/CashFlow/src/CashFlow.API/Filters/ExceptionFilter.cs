using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        throw new NotImplementedException();
    }

    private void HandleProjectException(ExceptionContext context) { }

    private void ThrowUnkownError(ExceptionContext context) { }
}
