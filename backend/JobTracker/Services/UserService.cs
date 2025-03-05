using JobTracker.Models;
using JobTracker.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace JobTracker.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _userRepository.GetAllAsync();
        public async Task<User?> GetUserByIdAsync(int id) => await _userRepository.GetByIdAsync(id);
        public async Task<User> AddUserAsync(User user) => await _userRepository.AddAsync(user);
        public async Task<bool> DeleteUserAsync(int id) => await _userRepository.DeleteAsync(id);
        public async Task<User?> GetUserByEmailAsync(string email) => await _userRepository.GetUserByEmailAsync(email);

    }
}