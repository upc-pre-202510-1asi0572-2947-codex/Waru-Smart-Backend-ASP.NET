namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

public record AddProductToSowingResource(
    int SowingId,
    int ProductId,
    int Quantity
    );