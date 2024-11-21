using CashFlow.Communication.Request;
using CashFlow.Communication.Response;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseJsonRegisterExpense Execute(RequestJsonRegisterExpense request)
    {
        return new ResponseJsonRegisterExpense();
    }

    public void Validate(RequestJsonRegisterExpense request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty)
        {
            throw new ArgumentException("The title is required.");
        }

        if (request.Amount <= 0) 
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }
    }
}
