using CashFlow.Communication.Request;
using CashFlow.Communication.Response;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseJsonRegisterExpense Execute(RequestJsonRegisterExpense request)
    {
        Validate(request);

        return new ResponseJsonRegisterExpense();
    }

    public void Validate(RequestJsonRegisterExpense request)
    {
        var validate = new RegisterExpenseValidator();

        var result = validate.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages); 
        }
    }
}
