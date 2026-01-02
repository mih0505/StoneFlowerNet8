using Domain.Common;

namespace Domain.OrderModels
{
    public class Customer
    {
        /// <summary>
        /// Имя заказчика
        /// </summary>
        public PersonName CustomerName { get; set; }
                
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Паспорт заказчика
        /// </summary>
        public Passport Passport { get; set; }

        /// <summary>
        /// Адрес заказчика
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Номера телефона заказчика
        /// </summary>
        public PhoneNumbers PhoneNumbers { get; set; }

        /// <summary>
        /// Договор
        /// </summary>
        public Order Order { get; set; }
    }
}