using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;

namespace MasterFarmSolution.Services
{
    public interface IFarmerService
    {
        Task<Farmer> CreateFarmer(string firstNameFarmer, string lastNameFarmer, string emailFarmer, string phoneFarmer, string addressFarmer);
        Task<List<Farmer>> GetAll();
        Task<Farmer> UpdateFarmer(int id, string? firstNameFarmer = null, string? lastNameFarmer = null, string? emailFarmer = null, string? phoneFarmer = null, string? addressFarmer = null);
        Task<Farmer> GetFarmer(int id);
        Task<Farmer> DeleteFarmer(int id);
    }
    public class FarmerService : IFarmerService
    {
        private readonly IFarmerRepository _farmerRepository;
        public FarmerService(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }
        public async Task<Farmer> CreateFarmer(string firstNameFarmer, string lastNameFarmer, string emailFarmer, string phoneFarmer, string addressFarmer)
        {
            return await _farmerRepository.CreateFarmer(firstNameFarmer, lastNameFarmer, emailFarmer, phoneFarmer, addressFarmer);

        }

        public async Task<Farmer> DeleteFarmer(int id)
        {
            Farmer desactiveFarmer = await _farmerRepository.GetFarmer(id);

            if (desactiveFarmer != null)
            {
                desactiveFarmer.is_active = false;
                return await _farmerRepository.DeleteFarmer(desactiveFarmer);
            }
            else
            {
                throw new Exception("Farmer not found");
            }
        }

        public async Task<List<Farmer>> GetAll()
        {
            return await _farmerRepository.GetAll();
        }

        public async Task<Farmer> GetFarmer(int id)
        {
            return await _farmerRepository.GetFarmer(id);
        }

        public async Task<Farmer> UpdateFarmer(int id, string? firstNameFarmer = null, string? lastNameFarmer = null, string? emailFarmer = null, string? phoneFarmer = null, string? addressFarmer = null)
        {
            Farmer newFarmer = await _farmerRepository.GetFarmer(id);

            if (newFarmer != null)
            {
                if (firstNameFarmer != null)
                {
                    newFarmer.firstNameFarmer = firstNameFarmer;
                }
                else if (lastNameFarmer != null)
                {
                    newFarmer.lastNameFarmer = lastNameFarmer;
                }
                else if (emailFarmer != null)
                {
                    newFarmer.emailFarmer = emailFarmer;
                }
                else if (phoneFarmer != null)
                {
                    newFarmer.phoneFarmer = phoneFarmer;
                }
                else if (addressFarmer != null)
                {
                    newFarmer.addressFarmer = addressFarmer;
                }
                return await _farmerRepository.UpdateFarmer(newFarmer);
            }
            else
                return null;
        }
    }
}
