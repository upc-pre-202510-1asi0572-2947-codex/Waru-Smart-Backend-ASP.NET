using WaruSmart.API.Crops.Domain.Model.ValueObjects;

namespace WaruSmart.API.Crops.Domain.Model.Commands;

public record CreateProductCommand(String Name, EProductType Type);