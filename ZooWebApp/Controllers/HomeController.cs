using Microsoft.AspNetCore.Mvc;
using ZooWebApp.Models;
using ZooWebApp.Models.ViewModels;
using ZooWebApp.Services;

namespace ZooWebApp.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IProductService productService, ILogger<HomeController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var viewModel = new HomeViewModel
            {
                Categories = (List<Category>)await _productService.GetCategoriesAsync(),
                FeaturedProducts = (List<Product>)await _productService.GetFeaturedProductsAsync()
            };

            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading home page");

            // Если ошибка, возвращаем пустую модель
            var viewModel = new HomeViewModel
            {
                Categories = new List<Category>(),
                FeaturedProducts = new List<Product>()
            };

            return View(viewModel);
        }
    }
}