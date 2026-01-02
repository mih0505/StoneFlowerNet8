using MediatR;

namespace ApplicationLayer.Operations.Common.Organization.Commands.Update
{
    internal class UpdateOrganizationCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
