using CommunityLibrary.Application.DTOs;
using CommunityLibrary.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CommunityLibrary.Api.Controllers
{
    /// <summary>
    /// Handles authentication-related HTTP requests such as login and registration.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token.
        /// </summary>
        /// <param name="loginDto">The login credentials</param>
        /// <returns>A JWT token if authentication is successful</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _authService.AuthenticateAsync(loginDto.Username, loginDto.Password);

            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            return Ok(new { token });
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="registerDto">The registration information</param>
        /// <returns>The created user information</returns>
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.RegisterAsync(new UserDto
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            }, registerDto.Password);

            return CreatedAtAction(nameof(Login), new { username = result.Username }, result);
        }
    }
}