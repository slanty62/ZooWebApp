using System.Collections.Generic;
using System.Threading.Tasks;
using ZooWebApp.Models;

namespace ZooWebApp.Services;

public interface IProductService
{
    Task<Product?> GetProductByIdAsync(int id);  // ← nullable
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>> GetFeaturedProductsAsync();
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(string? categoryName);  // ← nullable
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
    Task<bool> IsProductAvailableAsync(int id);
}