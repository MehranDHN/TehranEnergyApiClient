using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TehranEnergyApiClient.DomainModels.Models
{
    public class BldProperty
    {
        public int Pkid { get; set; }
        public string Title { get; set; }
        public Nullable<int> OwningType { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public Nullable<int> Region { get; set; }
        public Nullable<int> Zone { get; set; }
        public Nullable<int> UsageType { get; set; }
        public Nullable<double> Lon { get; set; }
        public Nullable<double> Lat { get; set; }
        public Nullable<int> FloorCount { get; set; }
        public string PSPlate { get; set; }
        public string RenewCode { get; set; }
        public string BldResponsible { get; set; }
        public string BldProfit { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> EstimatedEmployees { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public Nullable<decimal> BAreaMeter { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public Nullable<decimal> AreaMeter { get; set; }
        public Nullable<double> SLon { get; set; }
        public Nullable<double> Slat { get; set; }
        public Nullable<int> LocationGroupID { get; set; }
        public Nullable<int> PZone { get; set; }
        public Nullable<int> WZone { get; set; }
        public Nullable<int> GZone { get; set; }
        public virtual PowerCounter TargetPowerCounter { get; set; }
        public string UniqueTitle
        {
            get
            {
                string uniqueTitle = this.Title;
                if (!String.IsNullOrEmpty(this.Address))
                {
                    if (this.Address.Trim().Length > 30)
                    {
                        uniqueTitle = String.Format("{0} - {1}", this.Title, this.Address.Substring(0, 29));
                    }
                    else
                    {
                        uniqueTitle = String.Format("{0} - {1}", this.Title, this.Address);
                    }
                }
                return uniqueTitle;
            }
        }


        [NotMapped]
        public int RowSeq
        {
            get;
            set;
        }
    }
}
