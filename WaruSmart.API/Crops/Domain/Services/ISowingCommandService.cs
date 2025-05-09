using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.Entities;

namespace WaruSmart.API.Crops.Domain.Services;

public interface ISowingCommandService
{
    Task<Sowing> Handle(CreateSowingCommand command);
    Task<Sowing> Handle(int id, UpdateSowingCommand command);
    Task<bool> Handle(DeleteSowingCommand command);
    
    Task<Product> Handle(AddProductToSowingCommand command);
    Task<Sowing> Handle(UpdatePhenologicalPhaseBySowingIdCommand command);
}