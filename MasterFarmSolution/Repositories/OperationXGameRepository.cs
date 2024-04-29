using Azure;
using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface IOperationXGameRepository
    {
        Task<OperationXGame> CreateOperationXGame(int agriculturalOperationId, int gameId, DateTime dateTimeOperationXGame);
        Task<List<OperationXGame>> GetAll();
        Task<OperationXGame> UpdateOperationXGame(OperationXGame operationXGame);
        Task<OperationXGame> GetOperationXGame(int id);
        Task<OperationXGame> DeleteOperationXGame(OperationXGame operationXGame);
    }
    public class OperationXGameRepository : IOperationXGameRepository
    {
        private readonly ApplicationDbContext _db;
        public OperationXGameRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<OperationXGame> CreateOperationXGame(int agriculturalOperationId, int gameId, DateTime dateTimeOperationXGame)
        {
            OperationXGame newOperationXGame = new OperationXGame
            {
                agriculturalOperationId = agriculturalOperationId,
                gameId = gameId,
                dateTimeOperationXGame = dateTimeOperationXGame,
                is_active = true
            };
            await _db.OperationXGames.AddAsync(newOperationXGame);
            _db.SaveChanges();
            return newOperationXGame;
        }

        public async Task<OperationXGame> DeleteOperationXGame(OperationXGame operationXGame)
        {
            operationXGame.is_active = false;
            _db.OperationXGames.Update(operationXGame);
            await _db.SaveChangesAsync();
            return operationXGame;
        }

        public async Task<List<OperationXGame>> GetAll()
        {
            return await _db.OperationXGames.ToListAsync();
        }

        public async Task<OperationXGame> GetOperationXGame(int id)
        {
            return await _db.OperationXGames.FirstOrDefaultAsync(o => o.id == id);
        }

        public async Task<OperationXGame> UpdateOperationXGame(OperationXGame operationXGame)
        {
            _db.OperationXGames.Update(operationXGame);
            await _db.SaveChangesAsync();
            return operationXGame;
        }
    }
}
