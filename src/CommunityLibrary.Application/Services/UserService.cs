using AutoMapper;
using CommunityLibrary.Application.DTOs;
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
    /// 
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var createdUser = await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
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