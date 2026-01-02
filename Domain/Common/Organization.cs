namespace Domain.Common
{
    public class Organization : BaseModel
    {
        /// <summary>
        /// Название организации
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список филиалов
        /// </summary>
        public List<Department> Departments { get; set; }

        public Organization()
        {
            Departments = new List<Department>();
        }
    }
}
