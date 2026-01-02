namespace ApplicationLayer.Operations.Common.Department.Queries.GetDepartments
{
    internal class DepartmentDTOMapperProfile : AutoMapper.Profile
    {
        public DepartmentDTOMapperProfile()
        {
            CreateMap<Domain.Common.Department, DepartmentDTO>()
                .ForMember(
                    dto => dto.Address,
                    opt => opt.MapFrom(a => $"{a.Address.City}, " +
                    $"{a.Address.Street}, " +
                    $"{a.Address.House}, " +
                    $"{a.Address.Float}")
                )
                .ForMember(
                    dto => dto.PhoneNumbers,
                    opt => opt.MapFrom(a => $"{a.PhoneNumbers.PhoneNumber}, " +
                    $"{a.PhoneNumbers.AdvancedPhoneNumber}")
                );

        }
    }
}
