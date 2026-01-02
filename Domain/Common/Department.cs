using Domain.OrderModels;

namespace Domain.Common
{
    public class Department : BaseModel
    {
        /// <summary>
        /// Код филиала
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Организация
        /// </summary>
        public Organization Organization { get; set; }

        /// <summary>
        /// Название филиала
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Номера телефона филиала
        /// </summary>
        public PhoneNumbers PhoneNumbers { get; set; }

        /// <summary>
        /// Электронная почта филиала
        /// </summary>
        public string Email { get; set; }

        public IEnumerable<Order> DepartmentMaking { get; set; }
        public IEnumerable<Order> DepartmentOfExecution { get; set; }
        public IEnumerable<Payment> Money { get; set; }

        public Department()
        {
            DepartmentMaking = new List<Order>();
            DepartmentOfExecution = new List<Order>();
            Money = new List<Payment>();
        }
    }
}
