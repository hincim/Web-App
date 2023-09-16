using ShopApp.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Kategori adı zorunludur.")]
        [StringLength(100,MinimumLength =5,ErrorMessage = "Kategori adı 5 ile 100 karakter arasında olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Url zorunludur.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Url 5 ile 100 karakter arasında olmalıdır.")]
        public string Url { get; set; }
        public List<Product> Products { get; set; }

    }
}
