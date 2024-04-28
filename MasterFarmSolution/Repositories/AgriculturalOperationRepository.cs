using MasterFarmSolution.Entities;
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

        public Task<AgriculturalOperation> DeleteAgriculturalOperation(AgriculturalOperation agriculturalOperation)
        {
            throw new NotImplementedException();
        }

        public Task<AgriculturalOperation> GetAgriculturalOperation(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AgriculturalOperation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AgriculturalOperation> UpdateAgriculturalOperation(AgriculturalOperation agriculturalOperation)
        {
            throw new NotImplementedException();
        }
    }
}
