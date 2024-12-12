using AutoMapper;
using CashFlow.Communication.Request;
using CashFlow.Communication.Response;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper;

public class AutoMaping : Profile
{
    public AutoMaping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity() 
    {
        CreateMap<RequestJsonRegisterExpense, Expense>();
    }

    private void EntityToResponse() 
    {
        CreateMap<Expense, ResponseJsonRegisterExpense>();
    }
}
