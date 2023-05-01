using Domain.Entities;

namespace Repository.Business_Models
{
    internal class Product : IProduct
    {
        public int ProductId {get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public decimal Price { get; set;}
        public int Quantity {get; set;}
        public string PhotoUrl { get; set;}
    }
}
