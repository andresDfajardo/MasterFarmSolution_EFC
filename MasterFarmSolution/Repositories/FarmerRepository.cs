using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface IFarmerRepository
    {
        Task<Farmer> CreateFarmer(string firstNameFarmer, string lastNameFarmer, string emailFarmer, string phoneFarmer, string addressFarmer);
        Task<List<Farmer>> GetAll();
        Task<Farmer> UpdateFarmer(Farmer farmer);
        Task<Farmer> GetFarmer(int id);
        Task<Farmer> DeleteFarmer(Farmer farmer);
    }
    public class FarmerRepository : IFarmerRepository
    {
        private readonly ApplicationDbContext _db;
        public FarmerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Farmer> CreateFarmer(string firstNameFarmer, string lastNameFarmer, string emailFarmer, string phoneFarmer, string addressFarmer)
        {
            Farmer newFarmer = new Farmer
            {
                firstNameFarmer = firstNameFarmer,
                lastNameFarmer = lastNameFarmer,
                emailFarmer = emailFarmer,
                phoneFarmer = phoneFarmer,
                addressFarmer = addressFarmer,
                is_active = true
            };
            await _db.Farmers.AddAsync(newFarmer);
            _db.SaveChanges();
            return newFarmer;
        }

        public async Task<Farmer> DeleteFarmer(Farmer farmer)
        {
            farmer.is_active = false;
            _db.Farmers.Update(farmer);
            await _db.SaveChangesAsync();
            return farmer;
        }

        public async Task<List<Farmer>> GetAll()
        {
            return await _db.Farmers.ToListAsync();
        }

        public async Task<Farmer> GetFarmer(int id)
        {
            return await _db.Farmers.FirstOrDefaultAsync(f => f.id == id);
        }

        public async Task<Farmer> UpdateFarmer(Farmer farmer)
        {
            _db.Farmers.Update(farmer);
            await _db.SaveChangesAsync();
            return farmer;
        }
    }
}
