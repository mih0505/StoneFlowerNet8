using Domain.Common;

namespace Domain.ProductModels
{
    public class ProductProperty : BaseModel
    {
        /// <summary>
        /// Название характеристики
        /// </summary>
        public string Name { get; set; }
    }
}
