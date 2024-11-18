namespace MyFirstApi.Entities;

public class Laptop : Device
{
    public string GetModel()
    {
        var isConnected = IsConnected();

        if (isConnected)
            return "MacBook";

        return "unknow";
    }

    public override string GetBrand()
    {
        if (GetModel().Contains("MacBook"))
        {
            return "Apple";
        }

        return "White label";
    }
}
