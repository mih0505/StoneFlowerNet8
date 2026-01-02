using ApplicationLayer.Infrastructure;
using ApplicationLayer.Infrastructure.Exceptions;
using ApplicationLayer.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Operations.Common.Department.Commands.Update
{
    internal class UpdateDepartmentCommandHandler : RequestHandlerBase<UpdateDepartmentCommand, Unit>
    {
        public UpdateDepartmentCommandHandler(IStoneFlowersDbContext context) : base(context)
        { }

        public async override Task<Unit> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
        {
            var department = await db.Departments
                .FirstOrDefaultAsync(d => d.Id == command.Id, cancellationToken);

            if (department == null)
            {
                throw new NotFoundException(typeof(Domain.Common.Department), command.Id);
            }

            department.Code = command.Code;
            department.Organization = command.Organization;
            department.Name = command.Name;
            department.Address.City = command.City;
            department.Address.Street = command.Street;
            department.Address.House = command.House;
            department.Address.Float = command.Float;
            department.PhoneNumbers.PhoneNumber = command.PhoneNumber;
            department.PhoneNumbers.AdvancedPhoneNumber = command.AdvancedPhoneNumber;
            department.Email = command.Email;

            await db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
