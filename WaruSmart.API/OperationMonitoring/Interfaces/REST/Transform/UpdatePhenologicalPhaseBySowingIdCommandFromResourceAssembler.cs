using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public class UpdatePhenologicalPhaseBySowingIdCommandFromResourceAssembler
{
    public static UpdatePhenologicalPhaseBySowingIdCommand ToCommand(UpdatePhenologicalPhaseBySowingIdResource resource)
    {
        return new UpdatePhenologicalPhaseBySowingIdCommand(resource.Id);
    }
}