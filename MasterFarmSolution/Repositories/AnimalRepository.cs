using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface IAnimalRepository
    {
        Task<Animal> CreateAnimal(string nameAnimal, int plotId);
        Task<List<Animal>> GetAll();
        Task<Animal> UpdateAnimal(Animal animal);
        Task<Animal> GetAnimal(int id);
        Task<Animal> DeleteAnimal(Animal animal);
    }
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ApplicationDbContext _db;
        public AnimalRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Animal> CreateAnimal(string nameAnimal, int plotId)
        {
            Animal newAnimal = new Animal
            {
                nameAnimal = nameAnimal,
                plotId = plotId,
                is_active = true
            };
            await _db.Animals.AddAsync(newAnimal);
            _db.SaveChanges();
            return newAnimal;
        }

        public async Task<Animal> DeleteAnimal(Animal animal)
        {
            animal.is_active = false;
            _db.Animals.Update(animal);
            await _db.SaveChangesAsync();
            return animal;
        }

        public async Task<List<Animal>> GetAll()
        {
            return await _db.Animals.ToListAsync();
        }
        public async Task<Animal> GetAnimal(int id)
        {
            return await _db.Animals.FirstOrDefaultAsync(a => a.id == id);
        }
        public async Task<Animal> UpdateAnimal(Animal animal)
        {
            _db.Animals.Update(animal);
            await _db.SaveChangesAsync();
            return animal;
        }
    }
}
