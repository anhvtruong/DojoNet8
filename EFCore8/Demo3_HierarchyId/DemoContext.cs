using Microsoft.EntityFrameworkCore;

namespace EFCore8.Demo3_HierarchyId;

public class DemoContext : DbContext
{
    public DbSet<Halfling> Halflings { get; set; }

    public string ConnectionString { get; }

    public DemoContext()
    {
        ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=efcore8_demo3;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(ConnectionString, x => x.UseHierarchyId());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}