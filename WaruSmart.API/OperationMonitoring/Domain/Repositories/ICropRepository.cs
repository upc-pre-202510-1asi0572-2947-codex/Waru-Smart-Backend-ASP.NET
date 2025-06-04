using WaruSmart.API.OperationMonitoring.Domain.Model.Aggregates;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.OperationMonitoring.Domain.Repositories;

public interface ICropRepository: IBaseRepository<Crop>
{
    Task UpdateAsync(Crop crop);
    Task<IEnumerable<Crop>> FindAllAsync();

}