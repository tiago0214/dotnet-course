using AutoMapper;
using CashFlow.Communication.Request;
using CashFlow.Communication.Response;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _expensesRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public RegisterExpenseUseCase(
        IExpensesWriteOnlyRepository repository,
        IUnityOfWork unityOfWork,
        IMapper mapper)
    {
        _expensesRepository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseJsonRegisterExpense> Execute(RequestJsonRegisterExpense request)
    {
        Validate(request);

        var entity = _mapper.Map<Expense>(request);

        await _expensesRepository.Add(entity);

        await _unityOfWork.Commit();

        return _mapper.Map<ResponseJsonRegisterExpense>(entity);
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
