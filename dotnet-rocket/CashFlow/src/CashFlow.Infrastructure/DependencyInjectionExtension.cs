using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepository(services);
    }

    private static void AddRepository( IServiceCollection services )
    {
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IExpensesRepository, ExpensesReposiroty>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var conectionString = configuration.GetConnectionString("conection");

        var version = new Version(8, 0, 40);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(conectionString,serverVersion));
    }
}
