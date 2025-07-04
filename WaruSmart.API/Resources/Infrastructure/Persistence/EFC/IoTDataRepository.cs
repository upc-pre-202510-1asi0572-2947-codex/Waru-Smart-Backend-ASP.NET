﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using WaruSmart.API.Resources.Domain.Model;
using WaruSmart.API.Resources.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.Resources.Infrastructure.Persistence.EFC;

public class IoTDataRepository : BaseRepository<IoTData>, IIoTDataRepository
{
    private readonly AppDbContext _context;

    public IoTDataRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    
    
    public async Task<IEnumerable<IoTData>> GetDataByDeviceIdAsync(string deviceIdValue)
    {
        return await _context.Set<IoTData>()
            .Where(data => data.DeviceIdValue == deviceIdValue)
            .ToListAsync();
    }

    public async Task<IEnumerable<IoTData>> GetAllDataAsync()
    {
        return await _context.Set<IoTData>().ToListAsync();
    }

    public async Task AddDataAsync(IoTData data)
    {
        await _context.Set<IoTData>().AddAsync(data);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<IoTData>> GetDataBySowingAsync(string sowingId)
    {
        return await _context.Set<IoTData>()
            .Where(data => data.Zone == sowingId)
            .ToListAsync();
    }
    
    public async Task FogAsync()
    {
        var fogData = await GetFogDBData();
        await UpdateLocalDatabaseAsync(fogData);
    }

    private async Task<IEnumerable<IoTData>> GetFogDBData()
    {
        //TODO: Refactor this connection string to use a configuration file or environment variable
        var _connectionString = "server=localhost;port=3306;user=root;password=12345678;database=fog_db;";
        using var connection = new MySqlConnection(_connectionString);
        var query = @"
        SELECT 
            id,
            device_id_value AS DeviceIdValue,
            humidity_value as Humidity,
            temperature_value AS TemperatureValue,
            timestamp as Timestamp,
            soil_moisture_value AS SoilMoistureValue,
            zone as Zone
        FROM fog_db.sensor_data";
        return await connection.QueryAsync<IoTData>(query);
    }

    private async Task UpdateLocalDatabaseAsync(IEnumerable<IoTData> fogData)
    {
        foreach (var data in fogData)
        {
            var exists = await _context.Set<IoTData>()
                .AnyAsync(d => d.Id == data.Id);

            if (!exists)
            {
                await _context.Set<IoTData>().AddAsync(data);
            }
        }

        await _context.SaveChangesAsync();
    }
}