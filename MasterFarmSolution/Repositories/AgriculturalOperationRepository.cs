using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MasterFarmSolution.Repositories
{
    public interface IAgriculturalOperationRepository
    {
        Task<AgriculturalOperation> CreateAgriculturalOperation(int cropId, string dateOperation, int operationTypeId, string description);
        Task<List<AgriculturalOperation>> GetAll();
        Task<AgriculturalOperation> UpdateAgriculturalOperation(AgriculturalOperation agriculturalOperation);
        Task<AgriculturalOperation> GetAgriculturalOperation(int id);
        Task<AgriculturalOperation> DeleteAgriculturalOperation(AgriculturalOperation agriculturalOperation);
    }
    public class AgriculturalOperationRepository : IAgriculturalOperationRepository
    {
        private readonly ApplicationDbContext _db;
        public AgriculturalOperationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AgriculturalOperation> CreateAgriculturalOperation(int cropId, string dateOperation, int operationTypeId, string description)
        {
            AgriculturalOperation newAgriculturalOperation = new AgriculturalOperation
            {
                cropId = cropId,
                dateOperation = dateOperation,
                operationTypeId = operationTypeId,
                description = description,
                is_active = true
            };
            await _db.AgriculturalOperations.AddAsync(newAgriculturalOperation);
            _db.SaveChanges();
            return newAgriculturalOperation;
        }

        public async Task<AgriculturalOperation> DeleteAgriculturalOperation(AgriculturalOperation agriculturalOperation)
        {
            agriculturalOperation.is_active = false;
            _db.AgriculturalOperations.Update(agriculturalOperation);
            await _db.SaveChangesAsync();
            return agriculturalOperation;
        }

        public async Task<AgriculturalOperation> GetAgriculturalOperation(int id)
        {
            return await _db.AgriculturalOperations.FirstOrDefaultAsync(a => a.id == id);
        }

        public async Task<List<AgriculturalOperation>> GetAll()
        {
            return await _db.AgriculturalOperations.ToListAsync();
        }

        public async Task<AgriculturalOperation> UpdateAgriculturalOperation(AgriculturalOperation agriculturalOperation)
        {
            _db.AgriculturalOperations.Update(agriculturalOperation);
            await _db.SaveChangesAsync();
            return agriculturalOperation;
        }
    }
}
