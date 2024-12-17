
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Delete;

public class DeleteExpenseUseCase : IDeleteExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteExpenseUseCase(IExpensesWriteOnlyRepository repository, IUnityOfWork unityOfWork) 
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if(result == false)
        {
            throw new NotFoundException(ResourceErrorMessages.NOT_FOUND);
        }

        await _unityOfWork.Commit();
    }
}
