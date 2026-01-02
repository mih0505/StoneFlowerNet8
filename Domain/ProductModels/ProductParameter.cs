using Domain.Common;

namespace Domain.ProductModels
{
    public class ProductParameter : BaseModel
    {
        /// <summary>
        /// Продукт
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Характеристика продукта
        /// </summary>
        public ProductProperty Property { get; set; }

        /// <summary>
        /// Значение характеристики
        /// </summary>
        public string Value { get; set; }
    }
}
