using System;
using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres;";

        optionsBuilder.UseNpgsql(connection);

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Repair> Repairs { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<RepairType> RepairTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasMany(x => x.Vehicles).WithOne(x => x.Owner);
        modelBuilder.Entity<Client>().HasMany(x => x.Repairs).WithOne(x => x.Client);
        modelBuilder.Entity<Client>().HasOne(x => x.Shop).WithMany(x => x.Clients);

        modelBuilder.Entity<Repair>().HasOne(x => x.Shop).WithMany(x => x.Repairs);
        modelBuilder.Entity<Repair>().HasOne(x => x.Vehicle);
        modelBuilder.Entity<Repair>().HasOne(x => x.RepairType);

        modelBuilder.Entity<RepairType>().HasData(
            new RepairType()
            {
                Id = Guid.NewGuid(),
                Name = "Выправление вмятин",
                Cost = 5000,
            },
            new RepairType()
            {
                Id = Guid.NewGuid(),
                Name = "Замена масла",
                Cost = 8000,
            },
            new RepairType()
            {
                Id = Guid.NewGuid(),
                Name = "Замена двигателя",
                Cost = 500_000,
            },
            new RepairType()
            {
                Id = Guid.NewGuid(),
                Name = "Замена колес/покрышек",
                Cost = 2500,
            },
            new RepairType()
            {
                Id = Guid.NewGuid(),
                Name = "Установка радиоприемника",
                Cost = 800,
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}