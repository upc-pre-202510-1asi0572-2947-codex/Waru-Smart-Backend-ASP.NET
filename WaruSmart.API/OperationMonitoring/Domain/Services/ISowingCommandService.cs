using WaruSmart.API.OperationMonitoring.Domain.Model.Aggregates;
using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;

namespace WaruSmart.API.OperationMonitoring.Domain.Services;

public interface ISowingCommandService
{
    Task<Sowing> Handle(CreateSowingCommand command);
    Task<Sowing> Handle(int id, UpdateSowingCommand command);
    Task<bool> Handle(DeleteSowingCommand command);
    
    Task<Product> Handle(AddProductToSowingCommand command);
    Task<Sowing> Handle(UpdatePhenologicalPhaseBySowingIdCommand command);
}