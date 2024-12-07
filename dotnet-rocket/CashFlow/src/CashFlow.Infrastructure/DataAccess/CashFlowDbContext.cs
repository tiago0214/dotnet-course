using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

internal class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=root";

        var version = new Version(8,0,40);
        var serverVersion = new MySqlServerVersion(version);

        optionsBuilder.UseMySql(conectionString, serverVersion);
    }
}
