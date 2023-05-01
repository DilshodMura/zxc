using Domain.Entities;

namespace Services.DTO_models
{
    public sealed class OrderItemDTO : IOrderItem
    {
        public int OrderItemId {get;set;}
        public int ProductId { get;set;}    
        public int Quantity { get;set;} 
        public decimal Price { get;set;}    
    }
}
