using CashFlow.Communication.Enums;
using CashFlow.Communication.Request;
using CashFlow.Communication.Response;

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
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty)
        {
            throw new ArgumentException("The title is required.");
        }

        if (request.Amount <= 0) 
        {
            throw new ArgumentException("The amount must be greater than zero.");
        }

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (result > 0) 
        {
            throw new ArgumentException("Date can't be set in the future");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        if (paymentTypeIsValid == false)
        {
            throw new ArgumentException("Payment method is invalid.");
        }
    }
}
