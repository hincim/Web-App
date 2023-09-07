using ShopApp.WebUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.WebUI.Data
{
    public class CategoryRepository
    {
        private static List<Category> _categories = null;

        static CategoryRepository()
        {
            _categories = new List<Category>()
            {
                    new Category()
                {
                        CategoryId= 1,
                    Description = "Telefon",
                    Name = "Telefon",
                },
                    new Category()
                {
                        CategoryId= 2,
                    Description = "Bilgisayar",
                    Name = "Bilgisayar",
                },
                    new Category()
                {
                        CategoryId= 3,
                    Description = "Elektronik",
                    Name = "Elektronik",
                },
                    new Category()
                {
                        CategoryId= 4,
                    Description = "Beyaz Eşya",
                    Name = "Beyaz Eşya",
                }
            };
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
        public static void AddCategory(Category category)
        {
            _categories.Add(category);
        }
        public static Category GetCategoryById(int categoryid)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == categoryid);
        }
    }
}
