using Petfolio.Communication.Enums;

namespace Petfolio.Communication.Request;

public class RequestPet
{
    public string Name { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public PetType Type { get; set; }
}
