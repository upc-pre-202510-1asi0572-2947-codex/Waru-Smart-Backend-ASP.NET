using WaruSmart.API.Crops.Domain.Model.Aggregates;
using System;
using System.Threading.Tasks;
using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Crops.Domain.Services;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Crops.Application.CommandServices
{
    public class DiseaseCommandService(IDiseaseRepository diseaseRepository, IUnitOfWork unitOfWork) : IDiseaseCommandService
    {
      public async Task<Disease> Handle(CreateDiseaseCommand command)
        {
            var disease = new Disease
            {
                Name = command.Name,
                Description = command.Description,
                Solution = command.Solution,
            };

            try
            {
                await diseaseRepository.AddAsync(disease);
                await unitOfWork.CompleteAsync();
                return disease;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while trying to add the new Disease", e);
            }
        }
    }
}