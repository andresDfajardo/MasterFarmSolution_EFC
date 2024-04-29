using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;

namespace MasterFarmSolution.Services
{
    public interface IFarmService
    {
        Task<Farm> CreateFarm(string farmName, int farmerId);
        Task<List<Farm>> GetAll();
        Task<Farm> UpdateFarm(int id, string? farmName = null, int? farmerId = null);
        Task<Farm> GetFarm(int id);
        Task<Farm> DeleteFarm(int id);
    }
    public class FarmService : IFarmService
    {
        private readonly IFarmRepository _farmRepository;
        public FarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }
        public async Task<Farm> CreateFarm(string farmName, int farmerId)
        {
            return await _farmRepository.CreateFarm(farmName, farmerId);
        }

        public async Task<Farm> DeleteFarm(int id)
        {
            Farm desactiveFarm = await _farmRepository.GetFarm(id);

            if (desactiveFarm != null)
            {
                desactiveFarm.is_active = false;
                return await _farmRepository.DeleteFarm(desactiveFarm);
            }
            else
            {
                throw new Exception("Farm not found");
            }
        }

        public async Task<List<Farm>> GetAll()
        {
            return await _farmRepository.GetAll();
        }

        public async Task<Farm> GetFarm(int id)
        {
            return await _farmRepository.GetFarm(id);
        }

        public async Task<Farm> UpdateFarm(int id, string? farmName = null, int? farmerId = null)
        {
            Farm newFarm = await _farmRepository.GetFarm(id);

            if (newFarm != null)
            {
                if (farmName != null)
                {
                    newFarm.farmName = farmName;
                }
                else if (farmerId != null)
                {
                    newFarm.farmerId = (int)farmerId;
                }
                return await _farmRepository.UpdateFarm(newFarm);
            }
            else
                return null;
        }
    }
}
