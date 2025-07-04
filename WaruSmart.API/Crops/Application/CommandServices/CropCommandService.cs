using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Crops.Application.CommandServices;

public class CropCommandService : ICropCommandService
{
    private readonly ISowingRepository sowingRepository;
    private readonly ICropRepository cropRepository;
    private readonly IUnitOfWork unitOfWork;

    public CropCommandService(ICropRepository cropRepository, ISowingRepository sowingRepository,
        IUnitOfWork unitOfWork)
    {
        this.cropRepository = cropRepository;
        this.sowingRepository = sowingRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Crop> Handle(CreateCropCommand command)
    {
        var crop = new Crop(command.Name, command.Description, command.ImageUrl);

        try
        {
            await cropRepository.AddAsync(crop);
            await unitOfWork.CompleteAsync();
            return crop;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Crop", e);
        }
    }

    public async Task<Crop> Handle(int id, UpdateCropCommand command)
    {
        var crop = await cropRepository.FindByIdAsync(id);
        if (crop == null)
        {
            throw new Exception("Crop not found");
        }

        crop.Update(command.Name, command.Description);

        try
        {
            await cropRepository.UpdateAsync(crop);
            await unitOfWork.CompleteAsync();
            return crop;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to update the Crop", e);
        }
    }

    public async Task<Sowing> CreateSowingFromCrop(int id)
    {
        var crop = await cropRepository.FindByIdAsync(id);
        if (crop == null)
        {
            throw new Exception("Crop not found");
        }

        var sowing = new Sowing
        {
            CropId = crop.Id
        };

        await sowingRepository.AddAsync(sowing);
        await unitOfWork.CompleteAsync();
        return sowing;
    }

    public async Task<Crop> DeleteCrop(int id)
    {
        var crop = await cropRepository.FindByIdAsync(id);
        if (crop == null)
        {
            throw new Exception("Crop not found");
        }

        cropRepository.Remove(crop);
        await unitOfWork.CompleteAsync();

        return crop;
    }

    public async Task<Sowing> HandleCreateSowing(CreateSowingCommand createSowingCommand)
    {
        if (createSowingCommand == null)
        {
            throw new ArgumentNullException(nameof(createSowingCommand), "The provided sowing command is null.");
        }

        var sowing = new Sowing(createSowingCommand);

        try
        {
            await sowingRepository.AddAsync(sowing);
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Sowing to the repository.", e);
        }

        try
        {
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to save changes to the database.", e);
        }

        return sowing;
    }
}