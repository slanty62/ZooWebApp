using System;
using System.ComponentModel.DataAnnotations;

namespace ZoologicalStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название товара")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно быть от 3 до 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [StringLength(500, ErrorMessage = "Описание не может превышать 500 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        [Range(0.01, 100000, ErrorMessage = "Цена должна быть от 0.01 до 100000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Введите количество")]
        [Range(0, 1000, ErrorMessage = "Количество должно быть от 0 до 1000")]
        public int StockQuantity { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}