using ShopApp.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Display(Name ="Name",Prompt ="Enter product name")]
        [Required(ErrorMessage ="Name zorunlu bir alandır.")]
        [StringLength(60,MinimumLength =5,ErrorMessage ="Ürün ismi 5 ile 60 karakter arasında olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Url zorunlu bir alandır.")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Price zorunlu bir alandır.")]
        [Range(1,100000000000,ErrorMessage ="Fiyat negatif olamaz.")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "Description zorunlu bir alandır.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Description 5 ile 100 karakter arasında olmalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "ImageUrl zorunlu bir alandır.")]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
