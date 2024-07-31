using CommunityLibrary.Application.DTOs;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string username, string password);
        Task<UserDto> RegisterAsync(UserDto userDto, string password);
    }
}