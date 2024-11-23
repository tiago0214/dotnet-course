namespace CashFlow.Communication.Response;

public class ResponseJsonError
{
    public List<string> Error { get; set; }

    public ResponseJsonError(string errorMessage)
    {
        Error = new List<string>() { errorMessage };
    }

    public ResponseJsonError (List<string> errorMessages)
    {
        Error = errorMessages;
    }
}
