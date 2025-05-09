using WaruSmart.API.Crops.Domain.Model.ValueObjects;

namespace WaruSmart.API.Crops.Domain.Model.Queries;

public record GetProductsByTypeQuery
{
    public EProductType Type { get; }

    public GetProductsByTypeQuery(string type)
    {
        if (Enum.TryParse<EProductType>(type, out var productType))
        {
            Type = productType;
        }
        else
        {
            throw new ArgumentException("Invalid product type");
        }
    }
}