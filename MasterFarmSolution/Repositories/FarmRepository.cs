using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface IFarmRepository
    {
        Task<Farm> CreateFarm(string farmName, int farmerId);
        Task<List<Farm>> GetAll();
        Task<Farm> UpdateFarm(Farm farm);
        Task<Farm> GetFarm(int id);
        Task<Farm> DeleteFarm(Farm farm);
    }
    public class FarmRepository : IFarmRepository
    {
        private readonly ApplicationDbContext _db;
        public FarmRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Farm> CreateFarm(string farmName, int farmerId)
        {
            Farm newFarm = new Farm
            {
                farmName = farmName,
                farmerId = farmerId,
                is_active = true
            };
            await _db.Farms.AddAsync(newFarm);
            _db.SaveChanges();
            return newFarm;
        }

        public async Task<Farm> DeleteFarm(Farm farm)
        {
            farm.is_active = false;
            _db.Farms.Update(farm);
            await _db.SaveChangesAsync();
            return farm;
        }

        public async Task<List<Farm>> GetAll()
        {
            return await _db.Farms.ToListAsync();
        }

        public async Task<Farm> GetFarm(int id)
        {
            return await _db.Farms.FirstOrDefaultAsync(f => f.id == id);
        }

        public async Task<Farm> UpdateFarm(Farm farm)
        {
            _db.Farms.Update(farm);
            await _db.SaveChangesAsync();
            return farm;
        }
    }
}
