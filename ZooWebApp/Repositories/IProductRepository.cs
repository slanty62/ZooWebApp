using System.Collections.Generic;
using System.Threading.Tasks;
using ZooWebApp.Models;

namespace ZooWebApp.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);  // ← nullable
    Task<IEnumerable<Product>> GetAllAsync();
    Task<IEnumerable<Product>> GetFeaturedAsync();
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<int> SaveChangesAsync();
}