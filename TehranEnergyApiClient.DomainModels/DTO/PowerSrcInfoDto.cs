using System;
using System.Collections.Generic;
using System.Text;
using TehranEnergyApiClient.DomainModels.Models;

namespace TehranEnergyApiClient.DomainModels.DTO
{
    public class PowerSrcInfoDto
    {
        public string defaultport { get; set; }
        public Nullable<bool> ispaid { get; set; }
        public string payment_identifier { get; set; }
        public string company_name { get; set; }
        public Nullable<int> company_code { get; set; }
        public string phase { get; set; }
        public string voltage_type { get; set; }
        public string amper { get; set; }
        public string tariff_type { get; set; }
        public string customer_type { get; set; }
        public string national_code { get; set; }
        public string customer_name { get; set; }
        public string customer_family { get; set; }
        public string tel_number { get; set; }
        public string mobile_number { get; set; }
        public string service_add { get; set; }
        public string service_post_code { get; set; }
        public Nullable<decimal> total_bill_debt { get; set; }
        public Nullable<decimal> other_account_debt { get; set; }
        public Nullable<decimal> total_register_debt { get; set; }
        public string location_status { get; set; }
        public string serial_number { get; set; }
        public Nullable<System.DateTime> payment_dead_line { get; set; }
        public Nullable<System.DateTime> last_read_date { get; set; }
        public Nullable<System.DateTime> license_expire_date { get; set; }
        public Nullable<int> subscription_id { get; set; }
        public Nullable<int> file_serial_number { get; set; }
        public string bill_identifier { get; set; }
        public int Pkid { get; set; }
        public string contract_demand { get; set; }
        public int buildingId { get; set; }
        public string buildingName { get; set; }
        public List<PowerSrcUsage> UsageDetails { get; set; }
    }
}
