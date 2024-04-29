using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;

namespace MasterFarmSolution.Services
{
    public interface IHarvestRecordService
    {
        Task<HarvestRecord> CreateHarvestRecord(int operationId, int productId, int quantity);
        Task<List<HarvestRecord>> GetAll();
        Task<HarvestRecord> UpdateHarvestRecord(int id, int? operationId = null, int? productId = null, int? quantity = null);
        Task<HarvestRecord> GetHarvestRecord(int id);
        Task<HarvestRecord> DeleteHarvestRecord(int id);
    }
    public class HarvestRecordService : IHarvestRecordService
    {
        private readonly IHarvestRecordRepository _harvestRecordRepository;
        public HarvestRecordService(IHarvestRecordRepository harvestRecordRepository)
        {
            _harvestRecordRepository = harvestRecordRepository;
        }
        public async Task<HarvestRecord> CreateHarvestRecord(int operationId, int productId, int quantity)
        {
            return await _harvestRecordRepository.CreateHarvestRecord(operationId, productId, quantity);

        }

        public async Task<HarvestRecord> DeleteHarvestRecord(int id)
        {
            HarvestRecord desactiveHarvestRecordRepository = await _harvestRecordRepository.GetHarvestRecord(id);

            if (desactiveHarvestRecordRepository != null)
            {
                desactiveHarvestRecordRepository.is_active = false;
                return await _harvestRecordRepository.DeleteHarvestRecord(desactiveHarvestRecordRepository);
            }
            else
            {
                throw new Exception("Harvest Record not found");
            }
        }

        public async Task<List<HarvestRecord>> GetAll()
        {
            return await _harvestRecordRepository.GetAll();
        }

        public async Task<HarvestRecord> GetHarvestRecord(int id)
        {
            return await _harvestRecordRepository.GetHarvestRecord(id);
        }

        public async Task<HarvestRecord> UpdateHarvestRecord(int id, int? operationId = null, int? productId = null, int? quantity = null)
        {
            HarvestRecord newHarvestRecord = await _harvestRecordRepository.GetHarvestRecord(id);

            if (newHarvestRecord != null)
            {
                if (operationId != null)
                {
                    newHarvestRecord.operationId = (int)operationId;
                }else if (productId != null)
                {
                    newHarvestRecord.productId = (int)productId;
                }else if (quantity != null)
                {
                    newHarvestRecord.quantity = (int)quantity;
                }
                return await _harvestRecordRepository.UpdateHarvestRecord(newHarvestRecord);
            }
            else
                return null;
        }
    }
}
