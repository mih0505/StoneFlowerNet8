using MediatR;

namespace ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizations
{
    public class GetOrganizationsQuery : IRequest<List<OrganizationDTO>>
    {
    }
}
