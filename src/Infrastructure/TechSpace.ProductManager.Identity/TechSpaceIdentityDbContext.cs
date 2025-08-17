using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechSpace.ProductManager.Identity.Models;

namespace TechSpace.ProductManager.Identity;

public class TechSpaceIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public TechSpaceIdentityDbContext()
    {
    }

    public TechSpaceIdentityDbContext(DbContextOptions<TechSpaceIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();
}
