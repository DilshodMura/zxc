using System.ComponentModel.DataAnnotations;

namespace Database.Entites
{
    public class CustomerDb
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<OrderDb> Orders { get; set; }
    }
}
