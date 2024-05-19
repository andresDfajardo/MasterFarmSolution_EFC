using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;

namespace MasterFarmSolution.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(string userName, string password, int farmerId);
        Task<List<User>> GetAll();
        Task<User> UpdateUser(int id, string? userName = null, string? password = null, int? farmerId = null);
        Task<User> GetUser(int id);
        Task<User> DeleteUser(int id);
        Task<User> Authenticate(string username, string password);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUser(string userName, string password, int farmerId)
        {
            return await _userRepository.CreateUser(userName, password, farmerId);
        }

        public async Task<User> DeleteUser(int id)
        {
            User desactiveUser = await _userRepository.GetUser(id);

            if (desactiveUser != null)
            {
                desactiveUser.is_active = false;
                return await _userRepository.DeleteUser(desactiveUser);
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task<User> UpdateUser(int id, string? userName = null, string? password = null, int? farmerId = null)
        {
            User newUser = await _userRepository.GetUser(id);

            if (newUser != null)
            {
                if (userName != null)
                {
                    newUser.userName = userName;
                }
                else if (password != null)
                {
                    newUser.password = password;
                }
                else if (farmerId != null)
                {
                    newUser.farmerId = (int)farmerId;
                }
                return await _userRepository.UpdateUser(newUser);
            }
            else
                return null;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            return await _userRepository.Authenticate(username, password);
        }
    }
}
