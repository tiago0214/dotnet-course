using AutoMapper;
using CashFlow.Communication.Response;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;

public class GetAllExpenseUseCase : IGetAllExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;

    public GetAllExpenseUseCase(IExpensesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseJsonExpenses> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseJsonExpenses
        {
            Expenses = _mapper.Map<List<ShortExpenseResponseJson>>(result)
        };
    }
}
