using ApplicationLayer.Infrastructure;
using ApplicationLayer.Infrastructure.Exceptions;
using ApplicationLayer.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Operations.Common.Organization.Commands.Delete
{
    internal class DeleteOrganizationCommandHandler
        : RequestHandlerBase<DeleteOrganizationCommand, Unit>
    {
        public DeleteOrganizationCommandHandler(IStoneFlowersDbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(DeleteOrganizationCommand command, CancellationToken cancellationToken)
        {
            var organization = await db.Organizations
                .FirstOrDefaultAsync(d => d.Id == command.OrganizationId, cancellationToken);

            if (organization == null)
            {
                throw new NotFoundException(typeof(Domain.Common.Organization), command.OrganizationId);
            }

            organization.IsDeleted = true;
            await db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
