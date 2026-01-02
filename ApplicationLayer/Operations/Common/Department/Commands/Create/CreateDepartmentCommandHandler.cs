using ApplicationLayer.Infrastructure;
using ApplicationLayer.Interfaces;
using Domain.Common;

namespace ApplicationLayer.Operations.Common.Department.Commands.Create
{
    internal class CreateDepartmentCommandHandler
        : RequestHandlerBase<CreateDepartmentCommand, Guid>
    {
        public CreateDepartmentCommandHandler(IStoneFlowersDbContext context) : base(context)
        { }

        public override async Task<Guid> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
        {
            var department = new Domain.Common.Department
            {
                Id = Guid.NewGuid(),
                Code = command.Code,
                Organization = command.Organization,
                Name = command.Name,
                Address = new Address
                {
                    City = command.City,
                    Street = command.Street,
                    House = command.House,
                    Float = command.Float,
                },
                PhoneNumbers = new PhoneNumbers
                {
                    PhoneNumber = command.PhoneNumber,
                    AdvancedPhoneNumber = command.AdvancedPhoneNumber,
                },
                Email = command.Email,
            };

            await db.Departments.AddAsync(department);
            await db.SaveChangesAsync(cancellationToken);

            return department.Id;
        }
    }
}
