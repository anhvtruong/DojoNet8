using Microsoft.EntityFrameworkCore;

namespace EFCore8.Demo5_SentinelValues;

public class DemoContext : DbContext
{
    public DbSet<Person> People { get; set; }

    public string DbPath { get; }

    public DemoContext()
    {
        var workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        DbPath = Path.Join(projectDirectory, "db\\efcore8_demo5.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(b =>
        {
            b.Property(e => e.OverdraftCredit).HasDefaultValue(500).HasSentinel(-1);

            b.Property(e => e.Single).HasDefaultValueSql("true").HasSentinel(true);
        });
    }
}