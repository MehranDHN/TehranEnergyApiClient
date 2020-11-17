using System;
using System.Collections.Generic;
using System.Text;

namespace TehranEnergyApiClient.DomainModels.Models
{
    public class PowerSrcUsage
    {
        public string cold_normal_cons { get; set; }
        public string cold_peak_cons { get; set; }
        public string cold_low_cons { get; set; }
        public string warm_normal_cons { get; set; }
        public string warm_peak_cons { get; set; }
        public string warm_low_cons { get; set; }
        public Nullable<int> bill_serial { get; set; }
        public Nullable<int> sale_year { get; set; }
        public Nullable<int> sale_prd { get; set; }
        public Nullable<int> process_status { get; set; }
        public Nullable<int> normal_cons { get; set; }
        public Nullable<int> peak_cons { get; set; }
        public Nullable<int> low_cons { get; set; }
        public Nullable<int> friday_cons { get; set; }
        public Nullable<int> react_cons { get; set; }
        public Nullable<int> demand_read { get; set; }
        public Nullable<int> avg_cost { get; set; }
        public Nullable<decimal> bill_amt { get; set; }
        public Nullable<decimal> gross_amt { get; set; }
        public Nullable<decimal> insurance_amt { get; set; }
        public Nullable<decimal> tax_amt { get; set; }
        public Nullable<decimal> paytoll_amt { get; set; }
        public Nullable<decimal> power_paytoll_amt { get; set; }
        public Nullable<decimal> previous_energy_deb { get; set; }
        public Nullable<decimal> energy_amt { get; set; }
        public Nullable<decimal> reactive_amt { get; set; }
        public Nullable<decimal> demand_amt { get; set; }
        public Nullable<decimal> subsc_amt { get; set; }
        public Nullable<decimal> season_amt { get; set; }
        public Nullable<decimal> license_expire_amt { get; set; }
        public Nullable<decimal> free_amt { get; set; }
        public Nullable<decimal> warm_normal_amt { get; set; }
        public Nullable<decimal> warm_peak_amt { get; set; }
        public Nullable<decimal> warm_low_amt { get; set; }
        public Nullable<decimal> cold_normal_amt { get; set; }
        public Nullable<decimal> cold_peak_amt { get; set; }
        public Nullable<decimal> cold_low_amt { get; set; }
        public Nullable<decimal> gas_discount_amt { get; set; }
        public Nullable<decimal> discount_amt { get; set; }
        public Nullable<int> warm_days { get; set; }
        public Nullable<int> cold_days { get; set; }
        public Nullable<int> total_days { get; set; }
        public string bill_identifier { get; set; }
        public int Pkid { get; set; }
        public Nullable<System.DateTime> issue_date { get; set; }
        public Nullable<System.DateTime> prev_reading_date { get; set; }
        public Nullable<System.DateTime> reject_date { get; set; }
        public Nullable<System.DateTime> reading_date { get; set; }

        public PowerSrcInfo PowerSource { get; set; }

        public Nullable<int> TotalUsage
        {
            get
            {
                return normal_cons + peak_cons + low_cons;
            }
        }
    }



    public class NewPowerSrcUsage
    {
        public int bill_serial { get; set; }
        public int sale_year { get; set; }
        public int sale_prd { get; set; }
        public DateTime issue_date { get; set; }
        public int process_status { get; set; }
        public DateTime reject_date { get; set; }
        public DateTime prev_reading_date { get; set; }
        public DateTime reading_date { get; set; }
        public int normal_cons { get; set; }
        public int peak_cons { get; set; }
        public int low_cons { get; set; }
        public int friday_cons { get; set; }
        public int react_cons { get; set; }
        public int demand_read { get; set; }
        public int avg_cost { get; set; }
        public int bill_amt { get; set; }
        public int gross_amt { get; set; }
        public int insurance_amt { get; set; }
        public int tax_amt { get; set; }
        public int paytoll_amt { get; set; }
        public int power_paytoll_amt { get; set; }
        public int previous_energy_debit { get; set; }
        public int energy_amt { get; set; }
        public int reactive_amt { get; set; }
        public int demand_amt { get; set; }
        public int subsc_amt { get; set; }
        public int season_amt { get; set; }
        public int license_expire_amt { get; set; }
        public int free_amt { get; set; }
        public int gas_discount_amt { get; set; }
        public int discount_amt { get; set; }
        public int warm_amt { get; set; }
        public int cold_amt { get; set; }
        public int warm_days { get; set; }
        public int cold_days { get; set; }
        public int total_days { get; set; }
        public int bill_type { get; set; }
        public int bill_status { get; set; }
        public long bill_identifier { get; set; }
        public int prev_normaltime_reading { get; set; }
        public int prev_peaktime_reading { get; set; }
        public int prev_reactive_normaltime { get; set; }
        public int prev_lowtime_reading { get; set; }
        public int prev_weekendtime_reading { get; set; }
        public int active_normaltime_reading { get; set; }
        public int active_peaktime_reading { get; set; }
        public int active_lowtime_reading { get; set; }
        public int active_weekendtime_reading { get; set; }
        public int reactive_normaltime_reading { get; set; }
        public Nullable<int> TotalUsage
        {
            get
            {
                return normal_cons + peak_cons + low_cons;
            }
        }
    }


}
