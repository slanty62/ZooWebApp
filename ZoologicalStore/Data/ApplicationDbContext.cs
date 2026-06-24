using Microsoft.EntityFrameworkCore;
using ZoologicalStore.Models;

namespace ZoologicalStore.Data
{
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

            // Добавляем начальные данные
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Собаки", Description = "Товары для собак", ProductCount = 0 },
                new Category { Id = 2, Name = "Кошки", Description = "Товары для кошек", ProductCount = 0 },
                new Category { Id = 3, Name = "Птицы", Description = "Товары для птиц", ProductCount = 0 },
                new Category { Id = 4, Name = "Рыбы", Description = "Товары для рыб", ProductCount = 0 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Сухой корм для собак Royal Canin",
                    Description = "Высококачественный сухой корм для собак всех пород",
                    Price = 2500,
                    StockQuantity = 50,
                    Category = "Собаки",
                    ImageUrl = "/images/dog_food.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Игрушка-мяч для кошек",
                    Description = "Интерактивная игрушка для активных кошек",
                    Price = 450,
                    StockQuantity = 30,
                    Category = "Кошки",
                    ImageUrl = "/images/cat_toy.jpg"
                }
            );
        }
    }
}   