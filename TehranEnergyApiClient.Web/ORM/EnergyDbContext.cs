using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TehranEnergyApiClient.DomainModels.Models;

namespace TehranEnergyApiClient.Web.ORM
{
    public class EnergyDbContext : DbContext
    {
        public DbSet<PowerCounter> PowerCounter { get; set; }

        public DbSet<BldProperty> BldProperty { get; set; }

        public DbSet<PowerSrcInfo> PowerSrcInfo { get; set; }

        public DbSet<PowerSrcUsage> PowerSrcUsage { get; set; }

        public DbSet<PowerSrcPayment> PowerSrcPayment { get; set; }
        public EnergyDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(
          ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PowerCounter>().HasKey(pc => new { pc.TagIdentifier });
            modelBuilder.Entity<BldProperty>().HasKey(bl => new { bl.Pkid });
            modelBuilder.Entity<PowerSrcInfo>().HasKey(ps => new { ps.bill_identifier });
            modelBuilder.Entity<PowerSrcUsage>().HasKey(ps => new { ps.Pkid });
            modelBuilder.Entity<PowerSrcPayment>().HasKey(ps => new { ps.Pkid });

            // I had to create a relation based on exact model in SAPA(Formal Restfull API Service Provider)
            modelBuilder.Entity<PowerSrcInfo>()
                .HasOne(o => o.TargetCounter)
                .WithOne(o => o.RelatedInfo).HasForeignKey<PowerCounter>(f => f.TagIdentifier);


            // In Tehran's municipality each location/Building has one or more Power/Water/Gas Counter
            // Which we treat them as buildings assets
            modelBuilder.Entity<BldProperty>()
    .HasOne(o => o.TargetPowerCounter)
    .WithOne(o => o.TargetBuilding).HasForeignKey<PowerCounter>(f => f.LocationID);


            modelBuilder.Entity<PowerSrcUsage>()
              .HasOne(d => d.PowerSource)
              .WithMany(o => o.UsageDetails)
              .HasForeignKey(d => d.bill_identifier);



            base.OnModelCreating(modelBuilder);
        }
    }
}
