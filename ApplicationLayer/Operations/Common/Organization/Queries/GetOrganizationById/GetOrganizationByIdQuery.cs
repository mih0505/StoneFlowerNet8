using MediatR;

namespace ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizationById
{
    internal class GetOrganizationByIdQuery : IRequest<Domain.Common.Organization>
    {
        public Guid Id { get; set; }
    }
}
