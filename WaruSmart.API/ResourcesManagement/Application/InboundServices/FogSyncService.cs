using Microsoft.EntityFrameworkCore.Migrations.Operations;
using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Repositories;
using WaruSmart.API.ResourcesManagement.Domain.Repositories;
using WaruSmart.API.ResourcesManagement.Domain.Services;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.ResourcesManagement.Application.InboundServices;

public class FogSyncService:IFogSyncService
{
    private readonly IIoTDataRepository _repository;
    private readonly IDeviceRepository _deviceRepository;
    private readonly ISowingRepository _sowingRepository;
    private readonly IUnitOfWork _unitOfWork;
    

    public FogSyncService(IIoTDataRepository repository,
        IDeviceRepository deviceRepository,
        ISowingRepository sowingRepository)
    {
        _repository = repository;
        _deviceRepository = deviceRepository;
        _sowingRepository = sowingRepository;
    }
    
    private async Task UpdateData()
    {
        await _repository.FogAsync();
    }

    public async Task SyncFogDataAsync()
    {
        
        // Update data
        await UpdateData();
        // Traer todos los dispositivos del repositorio
        var devices = await _deviceRepository.FindAllAsync();
        var enumerable = devices as Device[] ?? devices.ToArray();
        if (!enumerable.Any())
        {
            Console.WriteLine("No devices found.");
            return;
        }

        var data = _repository.GetAllDataAsync();         

        foreach (var device in enumerable)
        {
            // Obtener el dato más reciente del dispositivo desde el repositorio de IoTData
            var latestData = (await _repository.GetAllDataAsync())
                .Where(d => d.DeviceIdValue == device.DeviceId)
                .OrderByDescending(d => d.Timestamp)
                .FirstOrDefault();
        
            if (latestData != null)
            {
                device.Humidity = latestData.Humidity;
                device.Temprature = latestData.TemperatureValue;
                device.LastSyncDate = latestData.Timestamp;
                device.SoilMoisture = latestData.SoilMoistureValue;
                try
                {
                    _deviceRepository.Update(device);
                    await _unitOfWork.CompleteAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}