using Demo1_ValueTypes.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore8.Demo1_ValueTypes;

public class DemoContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public string DbPath { get; }

    public DemoContext()
    {
        var workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        DbPath = Path.Join(projectDirectory, "db\\efcore8_demo1.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .ComplexProperty(e => e.Address);

        modelBuilder.Entity<Order>(b =>
        {
            b.ComplexProperty(e => e.BillingAddress);
            b.ComplexProperty(e => e.ShippingAddress);
        });
    }
}