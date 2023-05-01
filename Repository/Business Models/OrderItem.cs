using Domain.Entities;

namespace Repository.Business_Models
{
    public sealed class OrderItem:IOrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
