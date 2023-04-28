using System.ComponentModel.DataAnnotations;

namespace Database.Entites
{
    public class OrderDb
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal Total { get; set; }

        public virtual CustomerDb Customer { get; set; }

        public virtual ICollection<OrderItemDb> OrderItems { get; set; }
    }
}
