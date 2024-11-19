using Petfolio.Communication.Response;

namespace Petfolio.Application.UseCases.Pet.GetAll;

public class GetAllPetUseCase
{
    public ResponseAllPetJson Execute()
    {
        return new ResponseAllPetJson
        {
            Pets = new List<ResponseShortPetJson> 
            {
                new ResponseShortPetJson
                {
                    Id = 1,
                    Name = "pet1",
                    Type = Communication.Enums.PetType.Dog
                },
                new ResponseShortPetJson
                {
                    Id = 2,
                    Name = "pet2",
                    Type = Communication.Enums.PetType.Cat
                },
                new ResponseShortPetJson
                {
                    Id = 3,
                    Name = "pet3",
                    Type = Communication.Enums.PetType.Cat
                }
            }
        };
    }
}
