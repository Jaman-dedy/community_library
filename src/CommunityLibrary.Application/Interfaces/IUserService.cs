using CommunityLibrary.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for the User service in the Community Library system.
    /// This interface outlines the operations that can be performed on User entities,
    /// serving as an abstraction layer between the API controllers and the data access layer.
    /// </summary>
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}