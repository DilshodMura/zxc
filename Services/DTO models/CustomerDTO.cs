using Domain.Entities;

namespace Services.DTO_models
{
    public sealed class CustomerDTO : ICustomer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
