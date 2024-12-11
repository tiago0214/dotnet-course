using CashFlow.Communication.Request;
using CashFlow.Communication.Response;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly IUnityOfWork _unityOfWork;

    public RegisterExpenseUseCase(IExpensesRepository repository, IUnityOfWork unityOfWork)
    {
        _expensesRepository = repository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ResponseJsonRegisterExpense> Execute(RequestJsonRegisterExpense request)
    {
        Validate(request);

        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType,
        };

        await _expensesRepository.Add(entity);

        await _unityOfWork.Commit();

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
