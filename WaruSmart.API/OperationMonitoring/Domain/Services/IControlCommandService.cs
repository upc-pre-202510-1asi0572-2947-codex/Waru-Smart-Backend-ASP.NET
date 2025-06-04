using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;

namespace WaruSmart.API.OperationMonitoring.Domain.Services;

public interface IControlCommandService
{
    Task<Control> Handle(CreateControlCommand command);
    
    Task<Control> Handle(DeleteControlCommand command);

    Task<Control> Handle(UpdateControlCommand command);
}