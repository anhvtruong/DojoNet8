﻿// See https://aka.ms/new-console-template for more information
using EFCore8.Demo3_HierarchyId;
using Microsoft.EntityFrameworkCore;

using var context = new DemoContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var halflings = new List<Halfling> {
    new Halfling(HierarchyId.Parse("/"), "Balbo", 1167),
    new Halfling(HierarchyId.Parse("/1/"), "Mungo", 1207),
    new Halfling(HierarchyId.Parse("/2/"), "Pansy", 1212),
    new Halfling(HierarchyId.Parse("/3/"), "Ponto", 1216),
    new Halfling(HierarchyId.Parse("/4/"), "Largo", 1220),
    new Halfling(HierarchyId.Parse("/5/"), "Lily", 1222),
    new Halfling(HierarchyId.Parse("/1/1/"), "Bungo", 1246),
    new Halfling(HierarchyId.Parse("/1/2/"), "Belba", 1256),
    new Halfling(HierarchyId.Parse("/1/3/"), "Longo", 1260),
    new Halfling(HierarchyId.Parse("/1/4/"), "Linda", 1262),
    new Halfling(HierarchyId.Parse("/1/5/"), "Bingo", 1264),
    new Halfling(HierarchyId.Parse("/3/1/"), "Rosa", 1256),
    new Halfling(HierarchyId.Parse("/3/2/"), "Polo"),
    new Halfling(HierarchyId.Parse("/4/1/"), "Fosco", 1264),
    new Halfling(HierarchyId.Parse("/1/1/1/"), "Bilbo", 1290),
    new Halfling(HierarchyId.Parse("/1/3/1/"), "Otho", 1310),
    new Halfling(HierarchyId.Parse("/1/5/1/"), "Falco", 1303),
    new Halfling(HierarchyId.Parse("/3/2/1/"), "Posco", 1302),
    new Halfling(HierarchyId.Parse("/3/2/2/"), "Prisca", 1306),
    new Halfling(HierarchyId.Parse("/4/1/1/"), "Dora", 1302),
    new Halfling(HierarchyId.Parse("/4/1/2/"), "Drogo", 1308),
    new Halfling(HierarchyId.Parse("/4/1/3/"), "Dudo", 1311),
    new Halfling(HierarchyId.Parse("/1/3/1/1/"), "Lotho", 1310),
    new Halfling(HierarchyId.Parse("/1/5/1/1/"), "Poppy", 1344),
    new Halfling(HierarchyId.Parse("/3/2/1/1/"), "Ponto", 1346),
    new Halfling(HierarchyId.Parse("/3/2/1/2/"), "Porto", 1348),
    new Halfling(HierarchyId.Parse("/3/2/1/3/"), "Peony", 1350),
    new Halfling(HierarchyId.Parse("/4/1/2/1/"), "Frodo", 1368),
    new Halfling(HierarchyId.Parse("/4/1/3/1/"), "Daisy", 1350),
    new Halfling(HierarchyId.Parse("/3/2/1/1/1/"), "Angelica", 1381) 
};

context.AddRange(halflings);
context.SaveChanges();

var thirdGeneration = await context.Halflings
    .Where(halfling => halfling.PathFromPatriarch.GetLevel() == 2)
    .ToListAsync();
// Bungo, Belba, Longo, Linda, Bingo, Rosa, Polo, Fosco

var directAncestor = await context.Halflings
    .SingleOrDefaultAsync(
        ancestor => ancestor.PathFromPatriarch == context.Halflings
            .Single(descendent => descendent.Name == "Bilbo").PathFromPatriarch
            .GetAncestor(1)); // Bungo

var directDescendents = await context.Halflings
    .Where(descendent => descendent.PathFromPatriarch.GetAncestor(1) == context.Halflings
        .Single(ancestor => ancestor.Name == "Mungo").PathFromPatriarch)
    .ToListAsync(); // Bungo, Belba, Longo, Linda, Bingo

Console.WriteLine("Close!");