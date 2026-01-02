using Domain.Common;

namespace Domain.ProductModels
{
    public class Category : BaseModel
    {
        /// <summary>
        /// Родительская категория
        /// </summary>        
        public Category Parent { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список товаров категории
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Список подкатегорий
        /// </summary>
        public List<Category> SubCategories { get; set; }

        public Category()
        {
            Products = new List<Product>();
            SubCategories = new List<Category>();
        }
    }
}
