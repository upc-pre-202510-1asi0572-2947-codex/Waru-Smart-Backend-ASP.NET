using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Crops.Domain.Repositories;

public interface IPestRepository : IBaseRepository<Pest>
{
   Task<IEnumerable<Pest>> FindAllAsync();
   
   Task<IEnumerable<Pest>> GetPestByCropIdQuery(int cropId);

   
}