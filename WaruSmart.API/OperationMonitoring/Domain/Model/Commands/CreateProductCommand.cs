using WaruSmart.API.OperationMonitoring.Domain.Model.ValueObjects;

namespace WaruSmart.API.OperationMonitoring.Domain.Model.Commands;

public record CreateProductCommand(String Name, EProductType Type);