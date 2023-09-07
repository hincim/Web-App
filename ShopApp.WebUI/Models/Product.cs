using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(59, MinimumLength =10, ErrorMessage ="Ürün ismi 10-50 karakter arasında olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Fiyat bilgisi girilmeli")]
        [Range(1,10000000)]
        public double? Price { get; set; }
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public bool isApproved{ get; set; }
        [Required]
        public int? CategoryId { get; set; }
    }
}
