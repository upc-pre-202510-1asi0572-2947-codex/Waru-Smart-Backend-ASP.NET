using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.Entities;

namespace WaruSmart.API.Crops.Domain.Services;

public interface IControlCommandService
{
    Task<Control> Handle(CreateControlCommand command);
    
    Task<Control> Handle(DeleteControlCommand command);

    Task<Control> Handle(UpdateControlCommand command);
}