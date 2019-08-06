using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Npgsql.Logging;
using ProductMasterConsole.Model;

namespace ProductMasterConsole.Repository
{
    public partial class eftipsContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] {new ConsoleLoggerProvider((_, LogLevel) => LogLevel==Microsoft.Extensions.Logging.LogLevel.Information, true)});
        public eftipsContext()
        {
        }

        public eftipsContext(DbContextOptions<eftipsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        
        public virtual DbQuery<CustomModelForSP> ProductNames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseNpgsql("Host=localhost;Database=ef-tips;Username=postgres;Password=postgres@123");
                optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ProductName).IsRequired();
            });
        }
    }
}
