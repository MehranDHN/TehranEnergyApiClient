using System;
using System.Collections.Generic;
using System.Text;

namespace TehranEnergyApiClient.DomainModels.Models
{
    public class SaleInputModel
    {
        public string BILL_IDENTIFIER { get; set; }
        public string MobileNo { get; set; }
        public int fromyear { get; set; }
    }
}
