using MediatR;

namespace ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizationDetail
{
    public class GetOrganizationDetailQuery : IRequest<OrganizationDetailDTO>
    {
        public Guid Id { get; set; }
    }
}