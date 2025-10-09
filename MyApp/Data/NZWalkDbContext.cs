using System;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data;

public class NZWalkDbContext : DbContext
{
    public NZWalkDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Difficulty> Difficulties { get; set; }

    public DbSet<Region> Regions { get; set; }

    public DbSet<Walk> Walks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var difficulties = new List<Difficulty>()
        {
           new Difficulty() {

             Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
             Name="Easy"

           },

           new Difficulty() {

             Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
             Name="Medium"

           },

           new Difficulty() {

            Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
             Name="Hard"
             

           }

        };
        modelBuilder.Entity<Difficulty>().HasData(difficulties);

        var regions = new List<Region>()
        {
            new Region() { Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48424"), Name = "New Oakland" },
            new Region() { Id=Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48414"), Name = "New Zealand" },
            new Region() { Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48494"), Name = "New Jersey" }
        };

        modelBuilder.Entity<Region>().HasData(regions);
    }
}


