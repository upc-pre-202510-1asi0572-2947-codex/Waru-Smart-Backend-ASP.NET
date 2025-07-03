namespace WaruSmart.API.ResourcesManagement.Domain.Services;

public interface IFogSyncService
{
    Task SyncFogDataAsync();
    
    //Task SyncALlFogDataAsync();
}