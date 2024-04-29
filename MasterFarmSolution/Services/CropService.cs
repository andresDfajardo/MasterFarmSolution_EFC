using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;

namespace MasterFarmSolution.Services
{
    public interface ICropService
    {
        Task<Crop> CreateCrop(string name, string description, string harvestDays, int plotId);
        Task<List<Crop>> GetAll();
        Task<Crop> UpdateCrop(int id, string? name = null, string? description = null, string? harvestDays = null, int? plotId = null);
        Task<Crop> GetCrop(int id);
        Task<Crop> DeleteCrop(int id);
    }
    public class CropService : ICropService
    {
        private readonly ICropRepository _cropRepository;
        public CropService(ICropRepository cropRepository)
        {
            _cropRepository = cropRepository;
        }
        public async Task<Crop> CreateCrop(string name, string description, string harvestDays, int plotId)
        {
            return await _cropRepository.CreateCrop(name, description, harvestDays, plotId);

        }

        public async Task<Crop> DeleteCrop(int id)
        {
            Crop desactiveCrop = await _cropRepository.GetCrop(id);

            if (desactiveCrop != null)
            {
                desactiveCrop.is_active = false;
                return await _cropRepository.DeleteCrop(desactiveCrop);
            }
            else
            {
                throw new Exception("Crop not found");
            }
        }

        public async Task<List<Crop>> GetAll()
        {
            return await _cropRepository.GetAll();

        }

        public async Task<Crop> GetCrop(int id)
        {
            return await _cropRepository.GetCrop(id);
        }

        public async Task<Crop> UpdateCrop(int id, string? name = null, string? description = null, string? harvestDays = null, int? plotId = null)
        {
            Crop newCrop = await _cropRepository.GetCrop(id);

            if (newCrop != null)
            {
                if (name != null)
                {
                    newCrop.name = name;
                }
                else if (description != null)
                {
                    newCrop.description = description;
                }
                else if (harvestDays != null)
                {
                    newCrop.harvestDays = harvestDays;
                }
                else if (plotId != null)
                {
                    newCrop.plotId = (int)plotId;
                }
                return await _cropRepository.UpdateCrop(newCrop);
            }
            else
                return null;
        }
    }
}
