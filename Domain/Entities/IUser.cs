
namespace Domain.Entities
{
    public interface IUser
    {
        public string Id { get; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; }
    }
}
