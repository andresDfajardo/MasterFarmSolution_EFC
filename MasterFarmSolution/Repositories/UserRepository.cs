using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(string userName, string password, int farmerId);
        Task<List<User>> GetAll();
        Task<User> UpdateUser(User user);
        Task<User> GetUser(int id);
        Task<User> DeleteUser(User user);
        Task<User> Authenticate(string username, string password);
    }
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<User> CreateUser(string userName, string password, int farmerId)
        {
            User newUser = new User
            {
                userName = userName,
                password = password,
                farmerId = farmerId,
                is_active = true
            };
            await _db.Users.AddAsync(newUser);
            _db.SaveChanges();
            return newUser;
        }

        public async Task<User> DeleteUser(User user)
        {
            user.is_active = false;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _db.Users.ToListAsync();

        }

        public async Task<User> GetUser(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<User> UpdateUser(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.userName == username);


            if (user == null || user.password != password)
                return null;


            return user;
        }
    }
}
