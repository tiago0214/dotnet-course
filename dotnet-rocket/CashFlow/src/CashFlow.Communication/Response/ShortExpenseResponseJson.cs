namespace CashFlow.Communication.Response;

public class ShortExpenseResponseJson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
