using Microsoft.EntityFrameworkCore;
using ZooWebApp.Models;

namespace ZooWebApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Настройка связей
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Начальные данные - Категории
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Корм", Icon = "🍖", Description = "Premium корма для питомцев" },
            new Category { Id = 2, Name = "Игрушки", Icon = "🧸", Description = "Развивающие игрушки" },
            new Category { Id = 3, Name = "Уход", Icon = "🛁", Description = "Средства для гигиены" }
        );

        // Начальные данные - Товары
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Корм Royal Canin",
                Description = "Premium корм для взрослых кошек",
                Price = 1500m,
                StockCount = 50,
                ImageEmoji = "🐱",
                IsFeatured = true,
                IsOnSale = false,
                CategoryId = 1,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = 2,
                Name = "Игрушка-мяч с пищалкой",
                Description = "Развивающая игрушка для собак",
                Price = 500m,
                StockCount = 100,
                ImageEmoji = "⚽",
                IsFeatured = true,
                IsOnSale = true,
                Discount = 20,
                OldPrice = 625m,
                CategoryId = 2,
                CreatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = 3,
                Name = "Шампунь для собак",
                Description = "Гипоаллергенный шампунь",
                Price = 750m,
                StockCount = 30,
                ImageEmoji = "🧴",
                IsFeatured = true,
                IsOnSale = false,
                CategoryId = 3,
                CreatedAt = DateTime.UtcNow
            }
        );
    }
}