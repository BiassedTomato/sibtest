using System;
using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public AppContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres;";

        optionsBuilder.UseNpgsql(connection);

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Repair> Repairs { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Shop> Services { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasMany(x => x.Vehicles).WithOne(x => x.Owner);
        modelBuilder.Entity<Client>().HasMany(x => x.Repairs).WithOne(x => x.Client);

        modelBuilder.Entity<Client>().HasData(new Client { Id = Guid.NewGuid(), FirstName = "Arsern", LastName = "She", IdNumber = "123321" });
        base.OnModelCreating(modelBuilder);
    }
}