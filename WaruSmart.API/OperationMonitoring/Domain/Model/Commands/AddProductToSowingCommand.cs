namespace WaruSmart.API.OperationMonitoring.Domain.Model.Commands;

public record AddProductToSowingCommand(
    int SowingId,
    int ProductId,
    int Quantity,
    DateTime UseDate
    );