using CommunityLibrary.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Interfaces
{

    /// <summary>
    /// Defines the contract for the User service in the Community Library system.
    /// This interface outlines the operations that can be performed on User entities,
    /// serving as an abstraction layer between the API controllers and the data access layer.
    /// </summary>
    /// 
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(int id);
    }
}