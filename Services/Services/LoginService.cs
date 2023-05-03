using Domain.Entities;
using Domain.Repository;
using Domain.Service;
using Microsoft.AspNetCore.Identity;
using Services.DTO_models;
using System.Security.Claims;

namespace Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<IJwtTokens> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetEmailAsync(username);

            if (user == null)
            {
                throw new ApplicationException($"Invalid username or password");
            }

            var result = await _userRepository.CheckPasswordAsync(user, password);

            if (!result)
            {
                throw new ApplicationException($"Invalid username or password");
            }

            var identity = await _userRepository.GetClaimsIdentityAsync(user);
            var tokens = _jwtService.GenerateTokens(identity);
            return tokens;
        }
    }
}
