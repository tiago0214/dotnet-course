using AutoMapper;
using CashFlow.Communication.Response;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetById;

public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
    private readonly IMapper _mapper;
    private readonly IExpensesRepository _repository;

    public GetExpenseByIdUseCase(IExpensesRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ResponseJsonExpense> Execute(long id)
    {
        var result = await _repository.GetById(id);

        return _mapper.Map<ResponseJsonExpense>(result);
    }
}
