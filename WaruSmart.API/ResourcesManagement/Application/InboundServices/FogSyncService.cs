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
        await _repository.FogAsync();
    }
}