using Demo1_ValueTypes.Models;
using EFCore8.Demo1_ValueTypes;

using var context = new DemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {context.DbPath}.");

// Create
Console.WriteLine("Inserting a new customer");
var customer = new Customer
{
    Name = "Willow",
    Address = new() { Line1 = "Barking Gate", City = "Walpole St Peter", Country = "UK", PostCode = "PE14 7AV" }
};

context.Add(customer);
await context.SaveChangesAsync();