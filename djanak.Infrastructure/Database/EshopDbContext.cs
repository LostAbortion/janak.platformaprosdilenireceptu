using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using djanak.Domain.Entities;

namespace djanak.Infrastructure.Database
{
    public class EshopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Carousel> Carousels { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public EshopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DatabaseInit dbInit = new DatabaseInit();
            modelBuilder.Entity<Product>().HasData(dbInit.GetProducts());
            modelBuilder.Entity<Carousel>().HasData(dbInit.GetCarousels());
        }
    }
}
