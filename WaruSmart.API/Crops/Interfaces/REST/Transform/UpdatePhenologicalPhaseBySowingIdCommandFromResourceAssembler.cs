using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

public class UpdatePhenologicalPhaseBySowingIdCommandFromResourceAssembler
{
    public static UpdatePhenologicalPhaseBySowingIdCommand ToCommand(UpdatePhenologicalPhaseBySowingIdResource resource)
    {
        return new UpdatePhenologicalPhaseBySowingIdCommand(resource.Id);
    }
}