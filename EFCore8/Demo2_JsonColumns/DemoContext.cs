using Microsoft.EntityFrameworkCore;

namespace EFCore8.Demo2_JsonColumns;

public class DemoContext : DbContext
{
    public DbSet<Author> Authors { get; set; }

    public string DbPath { get; }

    public DemoContext()
    {
        var workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        DbPath = Path.Join(projectDirectory, "db\\efcore8_demo2.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .OwnsOne(
                author => author.Contact,
                ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
                    ownedNavigationBuilder
                        .OwnsOne(contact => contact.Address);
                });
    }
}