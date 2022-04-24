namespace InventoryManagementDataLayer.Data;
using InventoryManagementDataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class InventoryDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        var configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ItemEntityMap());
    }
    public DbSet<Product> Products { get; set; }
}