using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.Entities;

namespace WaruSmart.API.Crops.Domain.Services;

public interface IDiseaseCommandService
{
    Task<Disease> Handle(CreateDiseaseCommand command);
}