using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pinnacle.PIS.Server.Domain;

namespace Pinnacle.PIS.Repository
{
    public class PISEntities : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        //public CISEntities(DbContextOptions dbContextOptions) : base(dbContextOptions)
        //{ }
        private readonly IConfiguration _configuration;
        public PISEntities(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }
        public DbSet<ProductInfo> ProductInfos { get; set; } // DbSet for ProductInfo
        public DbSet<AvailableProductQuantity> AvailableProductQuantities { get; set; }
        public DbSet<ScanInventory> ScanInventories { get; set; }

        public DbSet<ImportedData> ImportedDatas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship
            modelBuilder.Entity<AvailableProductQuantity>()
                .HasOne(apq => apq.ProductInfo)
                .WithMany(pi => pi.AvailableProductQuantities)
                .HasForeignKey(apq => apq.ProductInfoId)
                .OnDelete(DeleteBehavior.Restrict); // Specify delete behavior if needed

            // Configure properties and constraints
            modelBuilder.Entity<AvailableProductQuantity>()
                .Property(apq => apq.Quantity)
                .HasDefaultValue(0);

            modelBuilder.Entity<AvailableProductQuantity>()
                .Property(apq => apq.CreatedDate)
                .IsRequired();

            modelBuilder.Entity<AvailableProductQuantity>()
                .Property(apq => apq.CreatedBy)
                .IsRequired();

            modelBuilder.Entity<ScanInventory>()
                .HasOne(si => si.ProductInfo)
                .WithMany(pi => pi.ScanInventories)
                .HasForeignKey(si => si.ProductInfoId)
                .OnDelete(DeleteBehavior.Restrict); // Specify delete behavior if needed

            // Additional configuration if needed
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PISConnection"))
            .UseLoggerFactory(this._loggerFactory);

#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
#endif
        }
    }
}
