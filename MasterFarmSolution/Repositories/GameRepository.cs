using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface IGameRepository
    {
        Task<Game> CreateGame(string dateLastConnection);
        Task<List<Game>> GetAll();
        Task<Game> UpdateGame(Game game);
        Task<Game> GetGame(int id);
        Task<Game> DeleteGame(Game game);
    }
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _db;
        public GameRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Game> CreateGame(string dateLastConnection)
        {
            Game newGame = new Game
            {
                dateLastConnection = dateLastConnection,
                is_active = true
            };
            await _db.Games.AddAsync(newGame);
            _db.SaveChanges();
            return newGame;
        }

        public async Task<Game> DeleteGame(Game game)
        {
            game.is_active = false;
            _db.Games.Update(game);
            await _db.SaveChangesAsync();
            return game;
        }

        public async Task<List<Game>> GetAll()
        {
            return await _db.Games.ToListAsync();
        }

        public async Task<Game> GetGame(int id)
        {
            return await _db.Games.FirstOrDefaultAsync(g => g.id == id);
        }

        public async Task<Game> UpdateGame(Game game)
        {
            _db.Games.Update(game);
            await _db.SaveChangesAsync();
            return game;
        }
    }
}
