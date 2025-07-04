using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Crops.Domain.Repositories
{
    public interface IControlRepository : IBaseRepository<Control>
    {
        Task<IEnumerable<Control>> FindBySowingIdAsync(int sowingId);
        
        Task<IEnumerable<Control>> FindByIdAndSowingIdAsync(int id, int sowingId);
    }
}