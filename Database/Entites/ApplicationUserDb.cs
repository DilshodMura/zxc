using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Database.Entites
{
    public class ApplicationUserDb : IdentityUser
    {
        [Required]
        public string Role { get; set; }
        public virtual ICollection<OrderDb> Orders { get; set; }
    }
}
