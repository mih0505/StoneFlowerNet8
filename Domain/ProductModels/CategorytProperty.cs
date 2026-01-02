using Domain.Common;

namespace Domain.ProductModels
{
    public class CategoryProperty : BaseModel
    {
        /// <summary>
        /// Категория продукта
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Характеристика категории продукта
        /// </summary>
        public ProductProperty Property { get; set; }
    }
}
