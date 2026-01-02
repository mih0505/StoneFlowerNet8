using ApplicationLayer.Infrastructure;
using ApplicationLayer.Interfaces;

namespace ApplicationLayer.Operations.Common.Organization.Commands.Create
{
    public class CreateOrganizationCommandHandler
        : RequestHandlerBase<CreateOrganizationCommand, Guid>
    {
        public CreateOrganizationCommandHandler(IStoneFlowersDbContext context) : base(context)
        { }

        public override async Task<Guid> Handle(CreateOrganizationCommand command, CancellationToken cancellationToken)
        {
            var organization = new Domain.Common.Organization
            {
                Id = Guid.NewGuid(),                
                Name = command.Name,
            };

            await db.Organizations.AddAsync(organization);
            await db.SaveChangesAsync(cancellationToken);

            return organization.Id;
        }                
    }
}
