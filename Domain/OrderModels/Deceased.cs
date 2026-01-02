using Domain.Common;

namespace Domain.OrderModels
{
    public class Deceased : BaseModel
    {
        /// <summary>
        /// Договор
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// ФИО усопшего
        /// </summary>
        public PersonName DeceasedName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Дата смерти
        /// </summary>
        public string DeathDate { get; set; }
    }
}
