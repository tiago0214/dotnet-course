namespace CashFlow.Communication.Response;

public class ResponseJsonError
{
    public string Error { get; set; } = string.Empty;

    public ResponseJsonError(string errorMessage)
    {
        Error = errorMessage;
    }
}
