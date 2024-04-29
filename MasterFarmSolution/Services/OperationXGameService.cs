using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;

namespace MasterFarmSolution.Services
{
    public interface IOperationXGameService
    {
        Task<OperationXGame> CreateOperationXGame(int agriculturalOperationId, int gameId, DateTime dateTimeOperationXGame);
        Task<List<OperationXGame>> GetAll();
        Task<OperationXGame> UpdateOperationXGame(int id, int? agriculturalOperationId = null, int? gameId = null, DateTime? dateTimeOperationXGame = null);
        Task<OperationXGame> GetOperationXGame(int id);
        Task<OperationXGame> DeleteOperationXGame(int id);
    }
    public class OperationXGameService : IOperationXGameService
    {
        private readonly IOperationXGameRepository _operationXGameRepository;
        public OperationXGameService(IOperationXGameRepository operationXGameRepository)
        {
            _operationXGameRepository = operationXGameRepository;
        }
        public async Task<OperationXGame> CreateOperationXGame(int agriculturalOperationId, int gameId, DateTime dateTimeOperationXGame)
        {
            return await _operationXGameRepository.CreateOperationXGame(agriculturalOperationId, gameId, dateTimeOperationXGame);
        }

        public async Task<OperationXGame> DeleteOperationXGame(int id)
        {
            OperationXGame desactiveOperationXGame = await _operationXGameRepository.GetOperationXGame(id);

            if (desactiveOperationXGame != null)
            {
                desactiveOperationXGame.is_active = false;
                return await _operationXGameRepository.DeleteOperationXGame(desactiveOperationXGame);
            }
            else
            {
                throw new Exception("Operation X Game not found");
            }
        }

        public async Task<List<OperationXGame>> GetAll()
        {
            return await _operationXGameRepository.GetAll();
        }

        public async Task<OperationXGame> GetOperationXGame(int id)
        {
            return await _operationXGameRepository.GetOperationXGame(id);
        }

        public async Task<OperationXGame> UpdateOperationXGame(int id, int? agriculturalOperationId = null, int? gameId = null, DateTime? dateTimeOperationXGame = null)
        {
            OperationXGame newOperationXGame = await _operationXGameRepository.GetOperationXGame(id);

            if (newOperationXGame != null)
            {
                if (agriculturalOperationId != null)
                {
                    newOperationXGame.agriculturalOperationId = (int)agriculturalOperationId;
                }else if (gameId != null)
                {
                    newOperationXGame.gameId = (int)gameId;
                }else if (dateTimeOperationXGame != null)
                {
                    newOperationXGame.dateTimeOperationXGame = (DateTime)dateTimeOperationXGame;
                }
                return await _operationXGameRepository.UpdateOperationXGame(newOperationXGame);
            }
            else
                return null;
        }
    }
}
