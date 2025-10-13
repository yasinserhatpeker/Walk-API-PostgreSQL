using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MyApp.Data;

public class NzWalkAuthDbContext : IdentityDbContext
{
   public NzWalkAuthDbContext(DbContextOptions<NzWalkAuthDbContext> options) : base(options)
    {
       
    }

}
