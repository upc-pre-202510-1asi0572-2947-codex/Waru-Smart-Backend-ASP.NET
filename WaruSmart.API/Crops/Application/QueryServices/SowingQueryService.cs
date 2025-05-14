﻿using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Model.Queries;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;

namespace WaruSmart.API.Crops.Application.QueryServices;

public class SowingQueryService(ISowingRepository sowingRepository)
: ISowingQueryService
{
    public async Task<Sowing?> Handle(GetSowingByIdQuery query)
    {
        return await sowingRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<Sowing>> Handle(GetSowingByStatusQuery query)
    {
        return await sowingRepository.FindByStatusAsync(query.Status);
    }

    public async Task<IEnumerable<Product>> Handle(GetProductsBySowingQuery query)
    {
        return await sowingRepository.FindProductsBySowing(query.SowingId);
    }

    public Task<IEnumerable<Sowing>> Handle(GetAllSowingsQuery query)
    {
        return sowingRepository.FindAllAsync();
    }

    public async Task<IEnumerable<Sowing>> Handle(GetAllSowingsByUserIdQuery query)
    {
        return await sowingRepository.FindAllByUserIdAsync(query.UserId);
    }
}