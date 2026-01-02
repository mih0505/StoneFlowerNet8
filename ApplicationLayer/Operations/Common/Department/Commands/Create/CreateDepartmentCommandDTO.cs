namespace ApplicationLayer.Operations.Common.Department.Commands.Create
{
    public class CreateDepartmentCommandDTO
    {
        public string Code { get; set; }
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int? Float { get; set; }
        public string PhoneNumber { get; set; }
        public string AdvancedPhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
