using WaruSmart.API.Crops.Domain.Model.Entities;

namespace WaruSmart.API.Crops.Domain.Model.Commands;



public record CreateCropCommand(string Name, string ImageUrl, string Description, List<int> Diseases, List<int> Pests, List<int> Cares);
