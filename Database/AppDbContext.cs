using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Technology_Tp1_React.Models;

namespace technology_tp1.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<DeliveryMan> DeliveryMen { get; set; }

        public DbSet<ItemImage> ItemImages { get; set; }

        public DbSet<MenuItem> MenuItems{ get; set; }

        public DbSet<AnonymousOrder> Orders { get; set; }

        //public IEnumerable<Order> OrdersInclude => Orders.Include(o => o.OrdersItems);

        public DbSet<OrdersItems> OrdersItems { get; set; }

        public AppDbContext(){}

        public AppDbContext(DbContextOptions options):base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersItems>()
                .HasIndex(p => new { p.OrderId, p.MenuItemId })
                .IsUnique(true);

            modelBuilder
                .Entity<DeliveryMan>()
                .HasData(Seed(ForgeFactory.ForgeDeliveryMan));

            modelBuilder
                .Entity<ItemImage>()
                .HasData(Seed(ForgeFactory.ForgeImageItem));

            modelBuilder
               .Entity<MenuItem>()
               .HasData(Seed(ForgeFactory.ForgeMenuItem));
        }

        private static IEnumerable<T> Seed<T>(ForgeJSONSeed<T> forge)
        {
            if (!forge.Exist)
            {
                forge.Forge();
            }

            return forge.Values;
        }
    }
}
