using EFCore8.Demo5_SentinelValues;

using var context = new DemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {context.DbPath}.");

// Create
Console.WriteLine("Inserting a new person");
var person = new Person
{
    Id = 1,
    OverdraftCredit = 0,
    Single = false
};

context.Add(person);
await context.SaveChangesAsync();

Console.WriteLine(person.OverdraftCredit);
Console.WriteLine(person.Single);