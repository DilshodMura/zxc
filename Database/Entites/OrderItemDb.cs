using System.ComponentModel.DataAnnotations;

namespace Database.Entites
{
    public class OrderItemDb
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual OrderDb Order { get; set; }

        public virtual ProductDb Product { get; set; }
    }
}
