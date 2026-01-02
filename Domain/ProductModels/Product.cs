using Domain.Common;

namespace Domain.ProductModels
{
    public class Product : BaseModel
    {
        /// <summary>
        /// Категория товара
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Список параметров товара
        /// </summary>
        public List<ProductParameter> Parameters;

        public Product()
        {
            Parameters = new List<ProductParameter>();
        }
    }
}
