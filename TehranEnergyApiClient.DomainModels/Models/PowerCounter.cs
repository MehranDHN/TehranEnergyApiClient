using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TehranEnergyApiClient.DomainModels.Models
{
    public class PowerCounter
    {
        public int Pkid { get; set; }
        public string FileNo { get; set; }
        public string TagIdentifier { get; set; }
        public string OwnerName { get; set; }
        public string BodySerial { get; set; }
        public string SubscribeNo { get; set; }
        public string Ceof { get; set; }
        public string ImgExtension { get; set; }
        public string Description { get; set; }
        public Nullable<bool> ArchiveFlag { get; set; }
        public Nullable<int> LocationID { get; set; }
        public Nullable<bool> LockFlag { get; set; }
        public Nullable<int> CntType { get; set; }

        public virtual BldProperty TargetBuilding { get; set; }

        public virtual PowerSrcInfo RelatedInfo { get; set; }
        [NotMapped]
        public int RowSeq
        {
            get; set;
        }
        public bool HasImage
        {
            get
            {
                bool hasImage = false;
                hasImage = !String.IsNullOrEmpty(this.ImgExtension) && this.ImgExtension.Trim().Length > 3;
                return hasImage;
            }

        }
    }
}
