using EFCore8.Demo2_JsonColumns;

using var context = new DemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {context.DbPath}.");

// Create
Console.WriteLine("Inserting a new author");
var author = new Author
{
    Name = "Willow",
    Contact = new()
    {
        Phone = "0123456789",
        Address = new() { Street = "Barking Gate", City = "Walpole St Peter", Country = "UK", Postcode = "PE14 7AV" }
    }
};

context.Add(author);
await context.SaveChangesAsync();