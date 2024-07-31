using CommunityLibrary.Application.Interfaces;
using CommunityLibrary.Core.Entities;
using CommunityLibrary.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Services
{
    /// <summary>
    /// Implements the IUserService interface to provide business logic for User-related operations.
    /// This service acts as an intermediary between the API controllers and the repository,
    /// encapsulating the application's business rules for managing users.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.ListAllAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user);
            }
        }
    }
}