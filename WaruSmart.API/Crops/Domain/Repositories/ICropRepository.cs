using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Crops.Domain.Repositories;

public interface ICropRepository: IBaseRepository<Crop>
{
    Task UpdateAsync(Crop crop);
    Task<IEnumerable<Crop>> FindAllAsync();

}