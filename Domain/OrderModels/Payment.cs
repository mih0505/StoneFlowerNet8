using Domain.Common;

namespace Domain.OrderModels
{
    public class Payment : BaseModel
    {
        /// <summary>
        /// Договор
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Дата платежа
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Сумма платежа
        /// </summary>
        public decimal Pay { get; set; }

        /// <summary>
        /// Филиал принявший платеж
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Пользователь принявший платеж
        /// </summary>
        public User User { get; set; }
    }
}
