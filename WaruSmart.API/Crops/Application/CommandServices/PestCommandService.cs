using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Crops.Application.CommandServices;

public class PestCommandService(IPestRepository pestRepository, IUnitOfWork unitOfWork)
    : IPestCommandService
{
    public async Task<Pest> Handle(CreatePestCommand command)
    {
        var pest = new Pest
        {
            Name = command.Name,
            Description = command.Description,
            Solution = command.Solution,
        };
        
        try
        {
            await pestRepository.AddAsync(pest);
            await unitOfWork.CompleteAsync();
            return pest;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Pest", e);
        }
    }
}