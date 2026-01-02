using Domain.Common;

namespace ApplicationLayer.Operations.Common.Department.Queries.GetDepartments
{
    public class DepartmentDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Organization { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }        
        public string PhoneNumbers { get; set; }        
        public string Email { get; set; }      
    }
}