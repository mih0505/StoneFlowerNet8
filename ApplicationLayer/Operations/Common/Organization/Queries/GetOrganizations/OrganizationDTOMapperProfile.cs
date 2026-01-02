namespace ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizations
{
    internal class OrganizationDTOMapperProfile : AutoMapper.Profile
    {
        public OrganizationDTOMapperProfile()
        {
            CreateMap<Domain.Common.Organization, OrganizationDTO>();
        }
    }
}
