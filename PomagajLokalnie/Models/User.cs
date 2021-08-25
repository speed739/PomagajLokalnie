using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace PomagajLokalnie.Models
{
    public partial class User : IdentityUser
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}
