using System.Collections.Generic;

namespace StoneFlowersWeb.Client.Models
{
    public class OrganizationDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<DepartmentDto> Departments { get; set; }
    }
}