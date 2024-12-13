using CashFlow.Communication.Response;

namespace CashFlow.Application.UseCases.Expenses.GetById;

public interface IGetExpenseByIdUseCase
{
    Task<ResponseJsonExpense> Execute(long id);
}
