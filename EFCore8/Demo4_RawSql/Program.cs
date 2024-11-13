using EFCore8.Demo4_RawSql;
using Microsoft.EntityFrameworkCore;

using var context = new DemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {context.DbPath}.");

context.Database.ExecuteSqlRaw(
    @"CREATE TABLE IF NOT EXISTS Posts (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Title TEXT NOT NULL,
        Content TEXT NOT NULL,
        PublishedOn DATE NOT NULL,
        BlogId INTEGER NOT NULL
    )"
);

context.Database.ExecuteSql(
    @$"INSERT INTO [Posts] ([Title], [Content], [PublishedOn], [BlogId])
        VALUES ('Post 1', 'This is the content of post 1.', '2021-01-01', 1),
                ('Post 2', 'This is the content of post 2.', '2022-02-05', 1),
                ('Post 3', 'This is the content of post 3.', '2022-03-10', 2),
                ('Post 4', 'This is the content of post 4.', '2023-04-15', 2);"
);

var start = new DateOnly(2022, 1, 1);
var end = new DateOnly(2023, 1, 1);
var postsIn2022 =
    await context.Database
        .SqlQuery<BlogPost>(
            $"SELECT * FROM Posts as p WHERE p.PublishedOn >= {start} AND p.PublishedOn < {end}")
        .ToListAsync();

Console.WriteLine(postsIn2022.All(p => p.PublishedOn.Year == 2022)); // true