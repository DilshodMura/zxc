using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Business_Models
{
    public sealed class Admin : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get { return "Admin"; } }
        public int AdminId { get; set; }
        public string FullName { get; set; }
    }
}
