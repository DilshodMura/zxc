using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Services.DTO_models;

namespace zxc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var tokens = await _loginService.LoginAsync(model.Email, model.Password);

            return Ok(tokens);
        }
    }
}
