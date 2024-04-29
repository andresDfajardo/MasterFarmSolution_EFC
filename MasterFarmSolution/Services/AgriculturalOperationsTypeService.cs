using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;
using Microsoft.OpenApi.Models;

namespace MasterFarmSolution.Services
{
    public interface IAgriculturalOperationsTypeService
    {
        Task<AgriculturalOperationsType> CreateAgriculturalOperationsType(string type);
        Task<List<AgriculturalOperationsType>> GetAll();
        Task<AgriculturalOperationsType> UpdateAgriculturalOperationsType(int id, string? type = null);
        Task<AgriculturalOperationsType> GetAgriculturalOperationsType(int id);
        Task<AgriculturalOperationsType> DeleteAgriculturalOperationsType(int id);
    }
    public class AgriculturalOperationsTypeService : IAgriculturalOperationsTypeService
    {
        private readonly IAgriculturalOperationsTypeRepository _agriculturalOperationsTypeRepository;
        public AgriculturalOperationsTypeService(IAgriculturalOperationsTypeRepository agriculturalOperationsTypeRepository)
        {
            _agriculturalOperationsTypeRepository = agriculturalOperationsTypeRepository;
        }
        public async Task<AgriculturalOperationsType> CreateAgriculturalOperationsType(string type)
        {
            return await _agriculturalOperationsTypeRepository.CreateAgriculturalOperationsType(type);
        }

        public async Task<AgriculturalOperationsType> DeleteAgriculturalOperationsType(int id)
        {
            AgriculturalOperationsType desactiveAgriculturalOperationsType = await _agriculturalOperationsTypeRepository.GetAgriculturalOperationsType(id);

            if (desactiveAgriculturalOperationsType != null)
            {
                desactiveAgriculturalOperationsType.is_active = false;
                return await _agriculturalOperationsTypeRepository.DeleteAgriculturalOperationsType(desactiveAgriculturalOperationsType);
            }
            else
            {
                throw new Exception("Agricultural Operation Type not found");
            }
        }

        public async Task<AgriculturalOperationsType> GetAgriculturalOperationsType(int id)
        {
            return await _agriculturalOperationsTypeRepository.GetAgriculturalOperationsType(id);
        }

        public async Task<List<AgriculturalOperationsType>> GetAll()
        {
            return await _agriculturalOperationsTypeRepository.GetAll();

        }

        public async Task<AgriculturalOperationsType> UpdateAgriculturalOperationsType(int id, string type = null)
        {
            AgriculturalOperationsType newAgriculturalOperationsType = await _agriculturalOperationsTypeRepository.GetAgriculturalOperationsType(id);

            if (newAgriculturalOperationsType != null)
            {
                if (type != null)
                {
                    newAgriculturalOperationsType.type = type;
                }
                return await _agriculturalOperationsTypeRepository.UpdateAgriculturalOperationsType(newAgriculturalOperationsType);
            }
            else
                return null;
        }
    }
}
