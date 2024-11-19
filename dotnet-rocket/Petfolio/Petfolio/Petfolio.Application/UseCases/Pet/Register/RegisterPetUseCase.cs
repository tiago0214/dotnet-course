using Petfolio.Communication.Request;
using Petfolio.Communication.Response;

namespace Petfolio.Application.UseCases.Pet.Register;

public class RegisterPetUseCase
{
    public ResponsePetRegisterJson Execute(RequestPet request)
    {
        return new ResponsePetRegisterJson()
        {
            Id = 1,
            Name = request.Name,
        };
    }
}
