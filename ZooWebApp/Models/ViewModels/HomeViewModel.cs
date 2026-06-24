using System.Collections.Generic;
using ZooWebApp.Models;

namespace ZooWebApp.Models.ViewModels  // ← Пространство имён
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; } = new();
        public List<Product> FeaturedProducts { get; set; } = new();
        public List<Product> SaleProducts { get; set; } = new();
    }
}