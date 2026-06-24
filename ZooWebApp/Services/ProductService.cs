using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooWebApp.Models;

namespace ZooWebApp.Services;

public class ProductService : IProductService
{
    // Заглушка с данными
    private readonly List<Product> _products = new()
    {
        new() { Id = 1, Name = "Корм Royal Canin", Price = 1500, Description = "Premium корм", ImageEmoji = "🐱", Category = new Category { Id = 1, Name = "Корм", Icon = "🍖" } },
        new() { Id = 2, Name = "Игрушка-мяч", Price = 500, Description = "Для активных игр", ImageEmoji = "⚽", Category = new Category { Id = 2, Name = "Игрушки", Icon = "🧸" } },
        new() { Id = 3, Name = "Шампунь для собак", Price = 750, Description = "Гипоаллергенный", ImageEmoji = "🧴", Category = new Category { Id = 3, Name = "Уход", Icon = "🛁" } }
    };

    public async Task<IEnumerable<Product>> GetFeaturedProductsAsync()
    {
        return await Task.FromResult(_products.Take(3));
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        var categories = new List<Category>
        {
            new() { Id = 1, Name = "Корм", Icon = "🍖", Description = "Premium корма" },
            new() { Id = 2, Name = "Игрушки", Icon = "🧸", Description = "Развивающие игрушки" },
            new() { Id = 3, Name = "Уход", Icon = "🛁", Description = "Средства для гигиены" }
        };
        return await Task.FromResult(categories.AsEnumerable());
    }

    // Остальные методы можно оставить пустыми или с заглушками
    public async Task<Product?> GetProductByIdAsync(int id) => await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    public async Task<IEnumerable<Product>> GetAllProductsAsync() => await Task.FromResult(_products.AsEnumerable());
    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string? categoryName) => await Task.FromResult(_products.AsEnumerable());
    public async Task<Product> CreateProductAsync(Product product) => await Task.FromResult(product);
    public async Task<Product> UpdateProductAsync(Product product) => await Task.FromResult(product);
    public async Task DeleteProductAsync(int id) => await Task.CompletedTask;
    public async Task<bool> IsProductAvailableAsync(int id) => await Task.FromResult(true);
}