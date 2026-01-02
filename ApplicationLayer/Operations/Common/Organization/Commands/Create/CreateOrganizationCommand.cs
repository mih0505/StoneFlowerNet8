using MediatR;

namespace ApplicationLayer.Operations.Common.Organization.Commands.Create
{
    public class CreateOrganizationCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
