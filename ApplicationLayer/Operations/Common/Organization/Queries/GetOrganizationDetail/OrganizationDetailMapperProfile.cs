using AutoMapper;
using ApplicationLayer.Operations.Common.Department.Queries.GetDepartments;

namespace ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizationDetail
{
    internal class OrganizationDetailMapperProfile : Profile
    {
        public OrganizationDetailMapperProfile()
        {
            CreateMap<Domain.Common.Organization, OrganizationDetailDTO>()
                .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.Departments));

            // DepartmentDTO mapping already exists in its profile
        }
    }
}