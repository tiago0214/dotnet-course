using Petfolio.Communication.Response;

namespace Petfolio.Application.UseCases.Pet.GetById;

public class GetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = id,
            Birthday = new DateTime(year: 2023, month: 02, day: 1),
            Name = "Petzinho",
            Type = Communication.Enums.PetType.Dog
        };
    }
}
