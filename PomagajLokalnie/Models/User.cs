using System;
using System.Collections.Generic;

#nullable disable

namespace PomagajLokalnie.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}
