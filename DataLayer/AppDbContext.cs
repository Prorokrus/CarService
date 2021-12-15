using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users;
        public DbSet<Order> Orders;
        public DbSet<Vehicle> Vehicles;
        public DbSet<Detail> Details;
        public DbSet<ServiceType> ServiceTypes;

        public AppDbContext(DbContextOptions settings)
            : base(settings)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.User);
                entity.HasOne(x => x.Detail);
                entity.HasOne(x => x.ServiceType);
                entity.HasOne(x => x.Vehicle);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.User);
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Price).HasPrecision(7, 2);
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Price).HasPrecision(7, 2);
                entity.Property(x => x.Duration).HasPrecision(7, 2);
            });
        }

    }
}
