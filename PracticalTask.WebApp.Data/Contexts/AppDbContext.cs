using Microsoft.EntityFrameworkCore;
using PracticalTask.WebApp.Data.Confirgurations;
using PracticalTask.WebApp.Data.Models;

namespace PracticalTask.WebApp.Data.Contexts;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}