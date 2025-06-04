namespace WaruSmart.API.OperationMonitoring.Domain.Model.Commands;

public record CreateProductBySowingCommand(int SowingId, int ProductId, int Quantity);