using Domain.Entities;

namespace Services.DTO_models
{
    public sealed class Order : IOrder
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }
    }
}
