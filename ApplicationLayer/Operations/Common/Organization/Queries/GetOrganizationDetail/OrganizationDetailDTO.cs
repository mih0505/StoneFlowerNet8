using ApplicationLayer.Operations.Common.Department.Queries.GetDepartments;

namespace ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizationDetail
{
    public class OrganizationDetailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<DepartmentDTO> Departments { get; set; }
    }
}