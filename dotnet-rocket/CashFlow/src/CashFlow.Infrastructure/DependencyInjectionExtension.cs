using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddDbContext(services);
        AddRepository(services);
    }

    private static void AddRepository( IServiceCollection services )
    {
        services.AddScoped<IExpensesRepository, ExpensesReposiroty>();
    }

    private static void AddDbContext(IServiceCollection services)
    {
        var conectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=root";

        var version = new Version(8, 0, 40);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(conectionString,serverVersion));
    }
}
