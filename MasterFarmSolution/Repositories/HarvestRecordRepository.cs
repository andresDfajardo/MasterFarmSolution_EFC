using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface IHarvestRecordRepository
    {
        Task<HarvestRecord> CreateHarvestRecord(int operationId, int productId, int quantity);
        Task<List<HarvestRecord>> GetAll();
        Task<HarvestRecord> UpdateHarvestRecord(HarvestRecord harvestRecord);
        Task<HarvestRecord> GetHarvestRecord(int id);
        Task<HarvestRecord> DeleteHarvestRecord(HarvestRecord harvestRecord);
    }
    public class HarvestRecordRepository : IHarvestRecordRepository
    {
        private readonly ApplicationDbContext _db;
        public HarvestRecordRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<HarvestRecord> CreateHarvestRecord(int operationId, int productId, int quantity)
        {
            HarvestRecord newHarvestRecord = new HarvestRecord
            {
                operationId = operationId,
                productId = productId,
                quantity = quantity,
                is_active = true
            };
            await _db.HarvestRecords.AddAsync(newHarvestRecord);
            _db.SaveChanges();
            return newHarvestRecord;
        }

        public async Task<HarvestRecord> DeleteHarvestRecord(HarvestRecord harvestRecord)
        {
            harvestRecord.is_active = false;
            _db.HarvestRecords.Update(harvestRecord);
            await _db.SaveChangesAsync();
            return harvestRecord;
        }

        public async Task<List<HarvestRecord>> GetAll()
        {
            return await _db.HarvestRecords.ToListAsync();
        }

        public async Task<HarvestRecord> GetHarvestRecord(int id)
        {
            return await _db.HarvestRecords.FirstOrDefaultAsync(h => h.id == id);
        }

        public async Task<HarvestRecord> UpdateHarvestRecord(HarvestRecord harvestRecord)
        {
            _db.HarvestRecords.Update(harvestRecord);
            await _db.SaveChangesAsync();
            return harvestRecord;
        }
    }
}
