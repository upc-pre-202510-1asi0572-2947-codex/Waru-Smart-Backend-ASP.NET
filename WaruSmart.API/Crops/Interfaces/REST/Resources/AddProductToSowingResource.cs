namespace WaruSmart.API.Crops.Interfaces.REST.Resources;

public record AddProductToSowingResource(
    int SowingId,
    int ProductId,
    int Quantity
    );