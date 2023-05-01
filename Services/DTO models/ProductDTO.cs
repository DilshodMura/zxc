using Domain.Entities;

namespace Services.DTO_models
{
    public sealed class ProductDTO : IProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PhotoUrl { get; set; }
    }
}
