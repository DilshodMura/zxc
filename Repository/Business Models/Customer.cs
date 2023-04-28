using Domain.Entities;

namespace Repository.Business_Models
{
    public sealed class Customer:ICustomer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
