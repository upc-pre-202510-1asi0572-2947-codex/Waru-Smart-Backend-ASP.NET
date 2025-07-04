﻿using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Crops.Application.CommandServices;

public class SowingCommandService(ISowingRepository sowingRepository, IUnitOfWork unitOfWork,
    IProductRepository productRepository,
    IProductsBySowingRepository productsBySowingRepository)
    : ISowingCommandService
{

    public async Task<Sowing> Handle(CreateSowingCommand command)
    {
        var sowing = new Sowing(command);
        try
        {
            await sowingRepository.AddAsync(sowing);
            await unitOfWork.CompleteAsync();
            return sowing;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new sowing", e);
        }
    }

    public async Task<Sowing> Handle(int id, UpdateSowingCommand command)
    {
        var sowing = await sowingRepository.FindByIdAsync(id);
        if (sowing == null)
        {
            throw new Exception("Sowing not found");
        }

        sowing.Update(command.AreaLand, command.CropId);

        try
        {
            await sowingRepository.UpdateAsync(sowing);
            await unitOfWork.CompleteAsync();
            return sowing;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to update the sowing", e);
        }
    }

    /**
     * Handle method to delete a sowing
     */

    public async Task<bool> Handle(DeleteSowingCommand command)
    {
        var sowing = await sowingRepository.FindByIdAsync(command.Id);
        if (sowing == null)
        {
            throw new Exception("Sowing not found");
        }

        try
        {
            sowingRepository.Remove(sowing);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to delete the sowing", e);
        }
    }


    public async Task<Product> Handle(AddProductToSowingCommand command)
    {
        var product = await productRepository.FindByIdAsync(command.ProductId);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
    
        var sowing = await sowingRepository.FindByIdAsync(command.SowingId);
        if (sowing == null)
        {
            throw new Exception("Sowing not found");
        }
    
        var productsBySowing = new ProductsBySowing(command);
    
        try
        {
            await productsBySowingRepository.AddAsync(productsBySowing);
            await unitOfWork.CompleteAsync();
            return product;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the product to the sowing", e);
        }
    }
    /**
     * Handle method to update the phenological phase of a sowing
     */

    public async Task<Sowing> Handle(UpdatePhenologicalPhaseBySowingIdCommand command)
{
    var sowing = await sowingRepository.FindByIdAsync(command.Id);
    if (sowing == null)
    {
        throw new Exception("Sowing not found");
    }

    sowing.IncrementPhenologicalPhase();

    try
    {
        await sowingRepository.UpdateAsync(sowing);
        await unitOfWork.CompleteAsync();
        return sowing; 
    }
    catch (Exception e)
    {
        throw new Exception("An error occurred while trying to update the sowing", e);
    }
}


}