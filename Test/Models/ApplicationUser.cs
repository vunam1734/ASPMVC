using System;
using Microsoft.AspNetCore.Identity;

namespace Test.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
