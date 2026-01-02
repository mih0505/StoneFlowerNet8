using ApplicationLayer.Infrastructure;
using ApplicationLayer.Infrastructure.Exceptions;
using ApplicationLayer.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Operations.Common.Organization.Commands.Update
{
    internal class UpdateOrganizationCommandHandler : RequestHandlerBase<UpdateOrganizationCommand, Unit>
    {
        public UpdateOrganizationCommandHandler(IStoneFlowersDbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(UpdateOrganizationCommand command, CancellationToken cancellationToken)
        {
            var organization = await db.Organizations
                .FirstOrDefaultAsync(d => d.Id == command.Id, cancellationToken);

            if (organization == null)
            {
                throw new NotFoundException(typeof(Domain.Common.Organization), command.Id);
            }            
            organization.Name = command.Name;
            

            await db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
