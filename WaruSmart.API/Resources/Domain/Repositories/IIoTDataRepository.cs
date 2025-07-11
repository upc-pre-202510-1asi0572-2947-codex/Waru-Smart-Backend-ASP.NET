﻿using WaruSmart.API.Resources.Domain.Model;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Resources.Domain.Repositories;

    public interface IIoTDataRepository : IBaseRepository<IoTData>
    {
        Task<IEnumerable<IoTData>> GetDataByDeviceIdAsync(string deviceIdValue);
        Task AddDataAsync(IoTData data);
        Task<IEnumerable<IoTData>> GetDataBySowingAsync(string sowingId);
        
        Task<IEnumerable<IoTData>> GetAllDataAsync();
        
        Task FogAsync();
        
        // Task<IEnumerable<IoTData>> GetFogDBData();
        
        // Task UpdateLocalDatabaseAsync(IEnumerable<IoTData> fogData);
    }