using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MasterFarmSolution.Repositories
{
    public interface IAgriculturalOperationsTypeRepository
    {
        Task<AgriculturalOperationsType> CreateAgriculturalOperationsType(string type);
        Task<List<AgriculturalOperationsType>> GetAll();
        Task<AgriculturalOperationsType> UpdateAgriculturalOperationsType(AgriculturalOperationsType agriculturalOperationsType);
        Task<AgriculturalOperationsType> GetAgriculturalOperationsType(int id);
        Task<AgriculturalOperationsType> DeleteAgriculturalOperationsType(AgriculturalOperationsType agriculturalOperationsType);
    }
    public class AgriculturalOperationsTypeRepository : IAgriculturalOperationsTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public AgriculturalOperationsTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AgriculturalOperationsType> CreateAgriculturalOperationsType(string type)
        {
            AgriculturalOperationsType newAgriculturalOperationsType = new AgriculturalOperationsType
            {
                type = type,
                is_active = true
            };
            await _db.AgriculturalOperationsTypes.AddAsync(newAgriculturalOperationsType);
            _db.SaveChanges();
            return newAgriculturalOperationsType;
        }

        public async Task<AgriculturalOperationsType> DeleteAgriculturalOperationsType(AgriculturalOperationsType agriculturalOperationsType)
        {
            agriculturalOperationsType.is_active = false;
            _db.AgriculturalOperationsTypes.Update(agriculturalOperationsType);
            await _db.SaveChangesAsync();
            return agriculturalOperationsType;
        }

        public async Task<AgriculturalOperationsType> GetAgriculturalOperationsType(int id)
        {
            return await _db.AgriculturalOperationsTypes.FirstOrDefaultAsync(a => a.id == id);
        }

        public async Task<List<AgriculturalOperationsType>> GetAll()
        {
            return await _db.AgriculturalOperationsTypes.ToListAsync();
        }

        public async Task<AgriculturalOperationsType> UpdateAgriculturalOperationsType(AgriculturalOperationsType agriculturalOperationsType)
        {
            _db.AgriculturalOperationsTypes.Update(agriculturalOperationsType);
            await _db.SaveChangesAsync();
            return agriculturalOperationsType;
        }
    }
}
