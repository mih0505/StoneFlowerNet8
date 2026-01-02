using MediatR;

namespace ApplicationLayer.Operations.Common.Organization.Commands.Delete
{
    internal class DeleteOrganizationCommand : IRequest<Unit>
    {
        public Guid OrganizationId { get; set; }
    }
}
