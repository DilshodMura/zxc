using System.ComponentModel.DataAnnotations;

namespace Database.Entites
{
    public class ProductDb
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string PhotoUrl { get; set; }

        public virtual ICollection<OrderItemDb> OrderItems { get; set; }
    }
}
