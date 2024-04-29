using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;

namespace MasterFarmSolution.Services
{
    public interface IAnimalService
    {
        Task<Animal> CreateAnimal(string nameAnimal, int plotId);
        Task<List<Animal>> GetAll();
        Task<Animal> UpdateAnimal(int id, string? nameAnimal = null, int? plotId = null);
        Task<Animal> GetAnimal(int id);
        Task<Animal> DeleteAnimal(int id);
    }
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<Animal> CreateAnimal(string nameAnimal, int plotId)
        {
            return await _animalRepository.CreateAnimal(nameAnimal, plotId);

        }

        public async Task<Animal> DeleteAnimal(int id)
        {
            Animal desactiveAnimal = await _animalRepository.GetAnimal(id);

            if (desactiveAnimal != null)
            {
                desactiveAnimal.is_active = false;
                return await _animalRepository.DeleteAnimal(desactiveAnimal);
            }
            else
            {
                throw new Exception("Animal not found");
            }
        }

        public async Task<List<Animal>> GetAll()
        {
            return await _animalRepository.GetAll();

        }

        public async Task<Animal> GetAnimal(int id)
        {
            return await _animalRepository.GetAnimal(id);
        }

        public async Task<Animal> UpdateAnimal(int id, string? nameAnimal = null, int? plotId = null)
        {
            Animal newAnimal = await _animalRepository.GetAnimal(id);

            if (newAnimal != null)
            {
                if (nameAnimal != null)
                {
                    newAnimal.nameAnimal = nameAnimal;
                }
                else if (plotId != null)
                {
                    newAnimal.plotId = (int)plotId;
                }
                return await _animalRepository.UpdateAnimal(newAnimal);
            }
            else
                return null;
        }
    }
}
