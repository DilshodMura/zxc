using Domain.Entities;

namespace Services.DTO_models
{
    public sealed class LoginDTO: ILoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
