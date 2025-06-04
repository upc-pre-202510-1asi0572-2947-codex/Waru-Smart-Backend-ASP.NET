using WaruSmart.API.OperationMonitoring.Domain.Model.Aggregates;
using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;

namespace WaruSmart.API.OperationMonitoring.Domain.Services;

public interface ICropCommandService
{
    Task<Crop> Handle(CreateCropCommand command);
    
    Task<Crop> Handle(int id, UpdateCropCommand command);

    Task<Sowing> CreateSowingFromCrop(int id);
    Task<Crop> DeleteCrop(int id);
    Task<Sowing> HandleCreateSowing(CreateSowingCommand createSowingCommand);
}