using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface ICropRepository
    {
        Task<Crop> CreateCrop(string name, string description, string harvestDays, int plotId);
        Task<List<Crop>> GetAll();
        Task<Crop> UpdateCrop(Crop crop);
        Task<Crop> GetCrop(int id);
        Task<Crop> DeleteCrop(Crop crop);
    }
    public class CropRepository : ICropRepository
    {
        private readonly ApplicationDbContext _db;
        public CropRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Crop> CreateCrop(string name, string description, string harvestDays, int plotId)
        {
            Crop newCrop = new Crop
            {
                name = name,
                description = description,
                harvestDays = harvestDays,
                plotId = plotId,
                is_active = true
            };
            await _db.Crops.AddAsync(newCrop);
            _db.SaveChanges();
            return newCrop;
        }

        public async Task<Crop> DeleteCrop(Crop crop)
        {
            crop.is_active = false;
            _db.Crops.Update(crop);
            await _db.SaveChangesAsync();
            return crop;
        }

        public async Task<List<Crop>> GetAll()
        {
            return await _db.Crops.ToListAsync();
        }

        public async Task<Crop> GetCrop(int id)
        {
            return await _db.Crops.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Crop> UpdateCrop(Crop crop)
        {
            _db.Crops.Update(crop);
            await _db.SaveChangesAsync();
            return crop;
        }
    }
}
