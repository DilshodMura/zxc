using Domain.Entities;

namespace Repository.Business_Models
{
    public class Customer : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get { return "Customer"; } }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
