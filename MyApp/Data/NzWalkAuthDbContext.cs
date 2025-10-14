using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MyApp.Data;

public class NzWalkAuthDbContext : IdentityDbContext
{
    public NzWalkAuthDbContext(DbContextOptions<NzWalkAuthDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var readerRoleId = "3f28e4b7-3a69-4a22-b60a-4a7f5877a0b9";
        var writerRoleId = "c1e2d5a9-77f4-4a9e-bd4a-3de47cb3a831";

        var roles = new List<IdentityRole>
        {
           new IdentityRole
           {
               Id=readerRoleId,
              ConcurrencyStamp=readerRoleId,
              Name="Reader",
             NormalizedName="Reader".ToUpper()
           },
          new IdentityRole
          {
              Id=writerRoleId,
              ConcurrencyStamp=writerRoleId,
              Name="Writer",
              NormalizedName="Writer".ToUpper()
          }

        };
        builder.Entity<IdentityRole>().HasData(roles);


    }
    

}
