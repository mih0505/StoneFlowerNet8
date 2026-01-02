using ApplicationLayer.Infrastructure;
using ApplicationLayer.Infrastructure.Exceptions;
using ApplicationLayer.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Operations.Common.Department.Commands.Delete
{
    internal class DeleteDepartmentCommandHandler : RequestHandlerBase<DeleteDepartmentCommand, Unit>
    {
        public DeleteDepartmentCommandHandler(IStoneFlowersDbContext context) : base(context)
        {}

        public override async Task<Unit> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
        {
            var department = await db.Departments
                .FirstOrDefaultAsync(d => d.Id == command.DepartmentId, cancellationToken);

            if (department == null)
            {
                throw new NotFoundException(typeof(Domain.Common.Department), command.DepartmentId);
            }

            department.IsDeleted = true;
            await db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
