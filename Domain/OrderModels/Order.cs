using Domain.Common;

namespace Domain.OrderModels
{
    public class Order : BaseModel
    {
        /// <summary>
        /// Номер договора
        /// </summary>
        public string Number { get; set; }

        public Customer Customer { get; set; }

        /// <summary>
        /// Дата оформления заказа
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата исполнения заказа
        /// </summary>
        public DateTime ExecutionDate { get; set;}

        /// <summary>
        /// Тип договора (приходный или расходный)
        /// </summary>
        public OrderType OrderType { get; set; }

        /// <summary>
        /// Количество платежей по рассрочке
        /// </summary>
        public int CountPayments { get; set; }

        /// <summary>
        /// Создатель заказа
        /// </summary>
        public User OrderCreator { get; set; }

        /// <summary>
        /// Филиал оформления заказа
        /// </summary>
        public Department DepartmentMakingOrder { get; set; }

        /// <summary>
        /// Филиал получения заказа
        /// </summary>
        public Department DepartmentOfExecution { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Заказ проверен
        /// </summary>
        public bool Verified { get; set; } = false;

        public IEnumerable<Deceased> Deceaseds { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public IEnumerable<OrderProduct> Products { get; set; }
        public Order() 
        {
            Deceaseds = new List<Deceased>();
            Payments = new List<Payment>();
            Products = new List<OrderProduct>();
        }
    }
}
