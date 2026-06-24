using System;

namespace ZooWebApp.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockCount { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageEmoji { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsOnSale { get; set; }
    public int? Discount { get; set; }
    public decimal? OldPrice { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}