using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ProAgil.Domain.Enum;

namespace ProAgil.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        [Column(TypeName= "NVARCHAR(150)")]
        public string FullName { get; set; }
        public Title Title { get; set; }
        public Function Function { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}