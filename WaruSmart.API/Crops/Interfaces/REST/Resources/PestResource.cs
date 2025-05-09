using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Entities;

namespace WaruSmart.API.Crops.Interfaces.REST.Resources;
public record PestResource(int Id, string Name, string Description, string Solution);