using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly IJwtService _jwtService;

        public TestController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet("generate")]
        public IActionResult GenerateToken()
        {
            // For demo purposes, let's just create a simple identity with a single claim
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "testuser") });

            // Generate JWT access token
            var accessToken = _jwtService.GenerateTokens(identity);

            return Ok(new { accessToken.AccessToken, accessToken.RefreshToken });
        }

        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            // Get user identity from JWT token
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            // Get username from identity
            var username = identity?.FindFirst(ClaimTypes.Name)?.Value;

            return Ok($"Hello, {username}! This is a protected route.");
        }
    }
}
