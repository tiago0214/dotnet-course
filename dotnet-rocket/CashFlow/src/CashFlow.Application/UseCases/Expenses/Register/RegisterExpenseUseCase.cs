using CashFlow.Communication.Request;
using CashFlow.Communication.Response;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseJsonRegisterExpense Execute(RequestJsonRegisterExpense request)
    {
        Validate(request);

        var dbContext = new CashFlowDbContext();

        var entity = new Expense
        {
            Id = 24,
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType,
        };

        dbContext.Expenses.Add(entity);

        dbContext.SaveChanges();

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
