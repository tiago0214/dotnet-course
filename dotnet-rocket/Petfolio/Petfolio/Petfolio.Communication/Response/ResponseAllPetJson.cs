namespace Petfolio.Communication.Response;

public class ResponseAllPetJson
{
    public List<ResponseShortPetJson> Pets { get; set; } = new List<ResponseShortPetJson>();
}
