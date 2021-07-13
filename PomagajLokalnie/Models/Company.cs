using System;
using System.Collections.Generic;

#nullable disable

namespace PomagajLokalnie.Models
{
    public partial class Company
    {
        public int Nip { get; set; }
        public string Name { get; set; }
        public string BankAccount { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
