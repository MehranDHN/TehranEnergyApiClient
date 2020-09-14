using System;
using System.Collections.Generic;
using System.Text;

namespace TehranEnergyApiClient.DomainModels.Models
{
    public class PowerSrcPayment
    {
        public string bill_identifier { get; set; }
        public Nullable<decimal> payment_amt { get; set; }
        public Nullable<int> bank_code { get; set; }
        public Nullable<int> ref_code { get; set; }
        public Nullable<int> chanel_type { get; set; }
        public int Pkid { get; set; }
        public Nullable<System.DateTime> payment_date { get; set; }
    }
}
