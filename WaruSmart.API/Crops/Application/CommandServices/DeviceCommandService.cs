using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Crops.Application.CommandServices;

public class DeviceCommandService(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork,
    ISowingRepository sowingRepository): IDeviceCommandService
{
    public async Task<Device?> Handle(CreateDeviceCommand command)
    {
        var sowing = sowingRepository.FindByIdAsync(command.sowingId);
        if (sowing == null)
        {
            throw new Exception("Sowing not found");
        }

        try
        {
            var device = new Device(command, sowing.Result);
            await deviceRepository.AddAsync(device);
            await unitOfWork.CompleteAsync();
            return device;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error creating device: " + e.Message);
            throw;
        }
        
    }
}