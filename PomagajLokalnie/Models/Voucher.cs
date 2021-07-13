using System;
using System.Collections.Generic;

#nullable disable

namespace PomagajLokalnie.Models
{
    public partial class Voucher
    {
        public int VoucherId { get; set; }
        public int? OfferId { get; set; }
        public double? StartAmount { get; set; }
        public double? CurrentAmount { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public virtual Offer Offer { get; set; }
    }
}
