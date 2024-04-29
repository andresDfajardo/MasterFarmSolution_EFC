using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;

namespace MasterFarmSolution.Services
{
    public interface IGameService
    {
        Task<Game> CreateGame(string dateLastConnection);
        Task<List<Game>> GetAll();
        Task<Game> UpdateGame(int id, string? dateLastConnection = null);
        Task<Game> GetGame(int id);
        Task<Game> DeleteGame(int id);
    }
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<Game> CreateGame(string dateLastConnection)
        {
            return await _gameRepository.CreateGame(dateLastConnection);
        }

        public async Task<Game> DeleteGame(int id)
        {
            Game desactiveGame = await _gameRepository.GetGame(id);

            if (desactiveGame != null)
            {
                desactiveGame.is_active = false;
                return await _gameRepository.DeleteGame(desactiveGame);
            }
            else
            {
                throw new Exception("Game not found");
            }
        }

        public async Task<List<Game>> GetAll()
        {
            return await _gameRepository.GetAll();

        }

        public async Task<Game> GetGame(int id)
        {
            return await _gameRepository.GetGame(id);
        }

        public async Task<Game> UpdateGame(int id, string dateLastConnection = null)
        {
            Game newGame = await _gameRepository.GetGame(id);

            if (newGame != null)
            {
                if (dateLastConnection != null)
                {
                    newGame.dateLastConnection = dateLastConnection;
                }
                return await _gameRepository.UpdateGame(newGame);
            }
            else
                return null;
        }
    }
}
