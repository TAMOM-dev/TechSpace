using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechSpace.ProductManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuditableEntity_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-47a8-9b10-c11d12e13f14"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "CPU" },
                    { new Guid("a7b8c9d0-e1f2-4d14-6b7c-8d9e0f1a2b3c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Case" },
                    { new Guid("b2c3d4e5-f6a7-48b9-1c2d-3e4f5a6b7c8d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Motherboard" },
                    { new Guid("b8c9d0e1-f2a3-4e25-7c8d-9e0f1a2b3c4d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Peripherals" },
                    { new Guid("c3d4e5f6-a7b8-49c0-2d3e-4f5a6b7c8d9e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "RAM" },
                    { new Guid("d4e5f6a7-b8c9-4ad1-3e4f-5a6b7c8d9e0f"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "GPU" },
                    { new Guid("e5f6a7b8-c9d0-4be2-4f5a-6b7c8d9e0f1a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Storage" },
                    { new Guid("f6a7b8c9-d0e1-4cf3-5a6b-7c8d9e0f1a2b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PSU" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreatedBy", "CreatedOn", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedOn", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("01234567-89ab-cdef-0123-456789abcdef"), new Guid("b8c9d0e1-f2a3-4e25-7c8d-9e0f1a2b3c4d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lightweight wireless gaming mouse with 30K DPI sensor for competitive play.", "https://example.com/images/razer-deathadder-v3-pro.jpg", null, null, "Razer DeathAdder V3 Pro Wireless Mouse", 149.99m, 35 },
                    { new Guid("89012345-6789-abcd-ef01-23456789abcd"), new Guid("a7b8c9d0-e1f2-4d14-6b7c-8d9e0f1a2b3c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premium mid-tower case with tempered glass side panel and excellent airflow.", "https://example.com/images/nzxt-h710.jpg", null, null, "NZXT H710 ATX Mid Tower Case", 169.99m, 12 },
                    { new Guid("90123456-789a-bcde-f012-3456789abcde"), new Guid("b8c9d0e1-f2a3-4e25-7c8d-9e0f1a2b3c4d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customizable mechanical gaming keyboard with hot-swappable switches.", "https://example.com/images/logitech-g-pro-x.jpg", null, null, "Logitech G Pro X Mechanical Keyboard", 129.99m, 40 },
                    { new Guid("a2b3c4d5-6e7f-8901-2345-6789abcdef01"), new Guid("a1b2c3d4-e5f6-47a8-9b10-c11d12e13f14"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "16-core, 32-thread unlocked processor for high-end gaming and productivity.", "https://example.com/images/ryzen-9-7950x.jpg", null, null, "AMD Ryzen 9 7950X", 549.99m, 20 },
                    { new Guid("b3c4d5e6-7f89-0123-4567-89abcdef0123"), new Guid("b2c3d4e5-f6a7-48b9-1c2d-3e4f5a6b7c8d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-end ATX motherboard with PCIe 5.0, DDR5 support, and advanced cooling.", "https://example.com/images/asus-z790-e.jpg", null, null, "ASUS ROG STRIX Z790-E", 429.99m, 10 },
                    { new Guid("c4d5e6f7-8901-2345-6789-abcdef012345"), new Guid("c3d4e5f6-a7b8-49c0-2d3e-4f5a6b7c8d9e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-performance DDR5 memory with RGB lighting for gaming PCs.", "https://example.com/images/corsair-vengeance-ddr5.jpg", null, null, "Corsair Vengeance RGB DDR5 32GB (2x16GB)", 189.99m, 30 },
                    { new Guid("d5e6f789-0123-4567-89ab-cdef01234567"), new Guid("d4e5f6a7-b8c9-4ad1-3e4f-5a6b7c8d9e0f"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flagship gaming GPU with 24GB GDDR6X memory and real-time ray tracing.", "https://example.com/images/rtx-4090.jpg", null, null, "NVIDIA GeForce RTX 4090", 1599.99m, 5 },
                    { new Guid("e6f78901-2345-6789-abcd-ef0123456789"), new Guid("e5f6a7b8-c9d0-4be2-4f5a-6b7c8d9e0f1a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-speed NVMe SSD with read speeds up to 7000MB/s for fast gaming and file access.", "https://example.com/images/samsung-980-pro.jpg", null, null, "Samsung 980 PRO 2TB NVMe SSD", 229.99m, 25 },
                    { new Guid("f1a1c2b3-4d5e-678f-9012-3456789abcde"), new Guid("a1b2c3d4-e5f6-47a8-9b10-c11d12e13f14"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "13th Gen Intel Core i9 processor with 24 cores and 32 threads for extreme performance.", "https://example.com/images/intel-i9-13900k.jpg", null, null, "Intel Core i9-13900K", 599.99m, 15 },
                    { new Guid("f7890123-4567-89ab-cdef-0123456789ab"), new Guid("f6a7b8c9-d0e1-4cf3-5a6b-7c8d9e0f1a2b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fully modular 80 PLUS Gold certified PSU for high-performance PCs.", "https://example.com/images/corsair-rm850x.jpg", null, null, "Corsair RM850x 850W Power Supply", 139.99m, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
