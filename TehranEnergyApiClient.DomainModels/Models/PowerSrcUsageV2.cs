using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TehranEnergyApiClient.DomainModels.Models
{
    public class PowerSrcUsageV2
    {
        public int Pkid { get; set; }
        public bool helper_flag { get; set; }
        public Nullable<int> bill_serial { get; set; }
        public Nullable<int> sale_year { get; set; }
        public Nullable<int> sale_prd { get; set; }
        public DateTime issue_date { get; set; }
        public Nullable<int> process_status { get; set; }
        public DateTime reject_date { get; set; }
        public DateTime prev_reading_date { get; set; }
        public DateTime reading_date { get; set; }
        public Nullable<int> normal_cons { get; set; }
        public Nullable<int> peak_cons { get; set; }
        public Nullable<int> low_cons { get; set; }
        public Nullable<int> friday_cons { get; set; }
        public Nullable<int> react_cons { get; set; }
        public Nullable<int> demand_read { get; set; }
        public Nullable<int> avg_cost { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal bill_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal gross_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal insurance_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal tax_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal paytoll_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal power_paytoll_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal previous_energy_debit { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal energy_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal reactive_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal demand_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal subsc_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal season_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal license_expire_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal free_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal gas_discount_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal discount_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal warm_amt { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal cold_amt { get; set; }
        public Nullable<int> warm_days { get; set; }
        public Nullable<int> cold_days { get; set; }
        public Nullable<int> total_days { get; set; }
        public Nullable<int> bill_type { get; set; }
        public Nullable<int> bill_status { get; set; }
        public string bill_identifier { get; set; }
        public Nullable<int> prev_normaltime_reading { get; set; }
        public Nullable<int> prev_peaktime_reading { get; set; }
        public Nullable<int> prev_reactive_normaltime { get; set; }
        public Nullable<int> prev_lowtime_reading { get; set; }
        public Nullable<int> prev_weekendtime_reading { get; set; }
        public Nullable<int> active_normaltime_reading { get; set; }
        public Nullable<int> active_peaktime_reading { get; set; }
        public Nullable<int> active_lowtime_reading { get; set; }
        public Nullable<int> active_weekendtime_reading { get; set; }
        public Nullable<int> reactive_normaltime_reading { get; set; }
    }
}
