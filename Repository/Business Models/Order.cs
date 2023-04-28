using Domain.Entities;

namespace Repository.Business_Models
{
    public sealed class Order: IOrder
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }
    }
}
