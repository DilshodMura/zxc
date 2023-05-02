//using Domain.Repository;
//using Domain.Service;
//using Microsoft.AspNetCore.Identity;
//using Services.DTO_models;
//using System.Security.Claims;

//namespace Services.Services
//{

//    public class AuthService
//    {
//        private readonly IUserService _userService;
//        private readonly IJwtService _jwtService;

//        public AuthService(IUserService userService, IJwtService jwtService)
//        {
//            _userService = userService;
//            _jwtService = jwtService;
//        }

//        public async Task<AuthResult> LoginAsync(LoginRequest request)
//        {
//            var user = await _userService.GetUserByEmailAsync(request.Email);

//            if (user == null)
//            {
//                return new AuthResult
//                {
//                    Errors = new[] { "Invalid login request" }
//                };
//            }

//            var passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

//            if (!passwordValid)
//            {
//                return new AuthResult
//                {
//                    Errors = new[] { "Invalid login request" }
//                };
//            }

//            var claims = new[]
//            {
//            new Claim(ClaimTypes.Name, user.Email),
//            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
//        };

//            var identity = new ClaimsIdentity(claims);

//            var tokens = _jwtService.GenerateTokens(identity);

//            return new JwtTokens
//            {
//                Success = true,
//                AccessToken = tokens.AccessToken,
//                RefreshToken = tokens.RefreshToken
//            };
//        }

//        public async Task<AuthResult> RefreshTokenAsync(string refreshToken)
//        {
//            var principal = _jwtService.ValidateAccessToken(refreshToken);

//            if (principal == null)
//            {
//                return new AuthResult
//                {
//                    Errors = new[] { "Invalid refresh token" }
//                };
//            }

//            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

//            if (string.IsNullOrEmpty(userId))
//            {
//                return new AuthResult
//                {
//                    Errors = new[] { "Invalid refresh token" }
//                };
//            }

//            var user = await _userService.GetUserByIdAsync(Convert.ToInt32(userId));

//            if (user == null || user.RefreshToken != refreshToken)
//            {
//                return new AuthResult
//                {
//                    Errors = new[] { "Invalid refresh token" }
//                };
//            }

//            var claims = new[]
//            {
//            new Claim(ClaimTypes.Name, user.Email),
//            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
//        };

//            var identity = new ClaimsIdentity(claims);

//            var tokens = _jwtService.GenerateTokens(identity);

//            user.RefreshToken = tokens.RefreshToken;
//            await _userService.UpdateUserAsync(user);

//            return new AuthResult
//            {
//                Success = true,
//                AccessToken = tokens.AccessToken,
//                RefreshToken = tokens.RefreshToken
//            };
//        }
//    }
//}
