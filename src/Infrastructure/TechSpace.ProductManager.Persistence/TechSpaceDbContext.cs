using System;
using Microsoft.EntityFrameworkCore;
using TachSpace.ProductManager.Domain.Common;
using TachSpace.ProductManager.Domain.Entities;

namespace TechSpace.ProductManager.Persistence;

public class TechSpaceDbContext : DbContext
{
    public TechSpaceDbContext(DbContextOptions<TechSpaceDbContext> options) : base(options)
    {

    }

    //Tables in the database
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechSpaceDbContext).Assembly);

        //seed data added through migrations
        var cpuGuid = Guid.Parse("{A1B2C3D4-E5F6-47A8-9B10-C11D12E13F14}");
        var motherboardGuid = Guid.Parse("{B2C3D4E5-F6A7-48B9-1C2D-3E4F5A6B7C8D}");
        var ramGuid = Guid.Parse("{C3D4E5F6-A7B8-49C0-2D3E-4F5A6B7C8D9E}");
        var gpuGuid = Guid.Parse("{D4E5F6A7-B8C9-4AD1-3E4F-5A6B7C8D9E0F}");
        var storageGuid = Guid.Parse("{E5F6A7B8-C9D0-4BE2-4F5A-6B7C8D9E0F1A}");
        var psuGuid = Guid.Parse("{F6A7B8C9-D0E1-4CF3-5A6B-7C8D9E0F1A2B}");
        var caseGuid = Guid.Parse("{A7B8C9D0-E1F2-4D14-6B7C-8D9E0F1A2B3C}");
        var peripheralsGuid = Guid.Parse("{B8C9D0E1-F2A3-4E25-7C8D-9E0F1A2B3C4D}");

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = cpuGuid,
            Name = "CPU"
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = motherboardGuid,
            Name = "Motherboard"
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = ramGuid,
            Name = "RAM"
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = gpuGuid,
            Name = "GPU"
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = storageGuid,
            Name = "Storage"
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = psuGuid,
            Name = "PSU"
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = caseGuid,
            Name = "Case"
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = peripheralsGuid,
            Name = "Peripherals"
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = Guid.Parse("{F1A1C2B3-4D5E-678F-9012-3456789ABCDE}"),
            Name = "Intel Core i9-13900K",
            ImageUrl = "https://example.com/images/intel-i9-13900k.jpg",
            Description = "13th Gen Intel Core i9 processor with 24 cores and 32 threads for extreme performance.",
            Stock = 15,
            Price = 599.99m,
            CategoryId = cpuGuid
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = Guid.Parse("{A2B3C4D5-6E7F-8901-2345-6789ABCDEF01}"),
            Name = "AMD Ryzen 9 7950X",
            ImageUrl = "https://example.com/images/ryzen-9-7950x.jpg",
            Description = "16-core, 32-thread unlocked processor for high-end gaming and productivity.",
            Stock = 20,
            Price = 549.99m,
            CategoryId = cpuGuid
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = Guid.Parse("{B3C4D5E6-7F89-0123-4567-89ABCDEF0123}"),
            Name = "ASUS ROG STRIX Z790-E",
            ImageUrl = "https://example.com/images/asus-z790-e.jpg",
            Description = "High-end ATX motherboard with PCIe 5.0, DDR5 support, and advanced cooling.",
            Stock = 10,
            Price = 429.99m,
            CategoryId = motherboardGuid
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = Guid.Parse("{C4D5E6F7-8901-2345-6789-ABCDEF012345}"),
            Name = "Corsair Vengeance RGB DDR5 32GB (2x16GB)",
            ImageUrl = "https://example.com/images/corsair-vengeance-ddr5.jpg",
            Description = "High-performance DDR5 memory with RGB lighting for gaming PCs.",
            Stock = 30,
            Price = 189.99m,
            CategoryId = ramGuid
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = Guid.Parse("{D5E6F789-0123-4567-89AB-CDEF01234567}"),
            Name = "NVIDIA GeForce RTX 4090",
            ImageUrl = "https://example.com/images/rtx-4090.jpg",
            Description = "Flagship gaming GPU with 24GB GDDR6X memory and real-time ray tracing.",
            Stock = 5,
            Price = 1599.99m,
            CategoryId = gpuGuid
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = Guid.Parse("{E6F78901-2345-6789-ABCD-EF0123456789}"),
            Name = "Samsung 980 PRO 2TB NVMe SSD",
            ImageUrl = "https://example.com/images/samsung-980-pro.jpg",
            Description = "High-speed NVMe SSD with read speeds up to 7000MB/s for fast gaming and file access.",
            Stock = 25,
            Price = 229.99m,
            CategoryId = storageGuid
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = Guid.Parse("{F7890123-4567-89AB-CDEF-0123456789AB}"),
            Name = "Corsair RM850x 850W Power Supply",
            ImageUrl = "https://example.com/images/corsair-rm850x.jpg",
            Description = "Fully modular 80 PLUS Gold certified PSU for high-performance PCs.",
            Stock = 18,
            Price = 139.99m,
            CategoryId = psuGuid
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = Guid.Parse("{89012345-6789-ABCD-EF01-23456789ABCD}"),
            Name = "NZXT H710 ATX Mid Tower Case",
            ImageUrl = "https://example.com/images/nzxt-h710.jpg",
            Description = "Premium mid-tower case with tempered glass side panel and excellent airflow.",
            Stock = 12,
            Price = 169.99m,
            CategoryId = caseGuid
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = Guid.Parse("{90123456-789A-BCDE-F012-3456789ABCDE}"),
            Name = "Logitech G Pro X Mechanical Keyboard",
            ImageUrl = "https://example.com/images/logitech-g-pro-x.jpg",
            Description = "Customizable mechanical gaming keyboard with hot-swappable switches.",
            Stock = 40,
            Price = 129.99m,
            CategoryId = peripheralsGuid
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = Guid.Parse("{01234567-89AB-CDEF-0123-456789ABCDEF}"),
            Name = "Razer DeathAdder V3 Pro Wireless Mouse",
            ImageUrl = "https://example.com/images/razer-deathadder-v3-pro.jpg",
            Description = "Lightweight wireless gaming mouse with 30K DPI sensor for competitive play.",
            Stock = 35,
            Price = 149.99m,
            CategoryId = peripheralsGuid
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}
