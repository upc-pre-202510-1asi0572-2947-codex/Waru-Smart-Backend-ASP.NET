/*
using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Crops.Application.CommandServices;

public class CareCommandService(ICareRepository careRepository, IUnitOfWork unitOfWork) : ICareCommandService
{
    public async Task<Care> Handle(CreateCareCommand command)
    {
        var care = new Care
        {
            Suggestion = command.suggestion,
            Date = command.date,
        };

        try
        {
            await careRepository.AddAsync(care);
            await unitOfWork.CompleteAsync();
            return care;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Care", e);
        }
    }
}
*/
