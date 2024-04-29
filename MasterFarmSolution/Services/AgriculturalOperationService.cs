using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace MasterFarmSolution.Services
{
    public interface IAgriculturalOperationService
    {
        Task<AgriculturalOperation> CreateAgriculturalOperation(int cropId, string dateOperation, int operationTypeId, string description);
        Task<List<AgriculturalOperation>> GetAll();
        Task<AgriculturalOperation> UpdateAgriculturalOperation(int id,int? cropId=null, string? dateOperation=null, int? operationTypeId=null, string? description=null);
        Task<AgriculturalOperation> GetAgriculturalOperation(int id);
        Task<AgriculturalOperation> DeleteAgriculturalOperation(int id);
    }

    public class AgriculturalOperationService : IAgriculturalOperationService
    {
        private readonly IAgriculturalOperationRepository _agriculturalOperationRepository;
        public AgriculturalOperationService(IAgriculturalOperationRepository agriculturalOperationRepository)
        {
            _agriculturalOperationRepository = agriculturalOperationRepository;
        }
        public async Task<AgriculturalOperation> CreateAgriculturalOperation(int cropId, string dateOperation, int operationTypeId, string description)
        {
            return await _agriculturalOperationRepository.CreateAgriculturalOperation(cropId, dateOperation, operationTypeId, description);
        }

        public async Task<AgriculturalOperation> DeleteAgriculturalOperation(int id)
        {
            AgriculturalOperation desactiveAgriculturalOperation = await _agriculturalOperationRepository.GetAgriculturalOperation(id);

            if (desactiveAgriculturalOperation != null)
            {
                desactiveAgriculturalOperation.is_active = false;
                return await _agriculturalOperationRepository.DeleteAgriculturalOperation(desactiveAgriculturalOperation);

            }
            else
            {
                throw new Exception("Agricultural Operation not found");
            }
        }

        public async Task<AgriculturalOperation> GetAgriculturalOperation(int id)
        {
            return await _agriculturalOperationRepository.GetAgriculturalOperation(id);
        }

        public async Task<List<AgriculturalOperation>> GetAll()
        {
            return await _agriculturalOperationRepository.GetAll();
        }

        public async Task<AgriculturalOperation> UpdateAgriculturalOperation(int id, int? cropId = null, string? dateOperation = null, int? operationTypeId = null, string? description = null)
        {
            AgriculturalOperation newAgriculturalOperation = await _agriculturalOperationRepository.GetAgriculturalOperation(id);

            if (newAgriculturalOperation != null)
            {
                if (cropId != null)
                {
                    newAgriculturalOperation.cropId = (int)cropId;
                }
                else if (dateOperation != null)
                {
                    newAgriculturalOperation.dateOperation = dateOperation;
                }
                else if (operationTypeId != null)
                {
                    newAgriculturalOperation.operationTypeId = (int)operationTypeId;
                }
                else if (description != null)
                {
                    newAgriculturalOperation.description = description;
                }
                return await _agriculturalOperationRepository.UpdateAgriculturalOperation(newAgriculturalOperation);
            }
            else
                return null;
        }
    }
}
