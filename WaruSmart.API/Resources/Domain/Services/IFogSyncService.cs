namespace WaruSmart.API.Resources.Domain.Services;

public interface IFogSyncService
{
    Task SyncFogDataAsync();
    
    //Task SyncALlFogDataAsync();
}