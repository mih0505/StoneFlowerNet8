using ApplicationLayer.Infrastructure;
using ApplicationLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Operations.Common.Department.Queries.GetDepartmentById
{
    internal class GetDepartmentByIdHandler : RequestHandlerBase<GetDepartmentByIdQuery, Domain.Common.Department>
    {
        public GetDepartmentByIdHandler(IStoneFlowersDbContext context) : base(context)
        { }

        public override async Task<Domain.Common.Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await db.Departments
                .Include(org => org.Organization)
                .FirstOrDefaultAsync(dep => dep.Id == request.Id, cancellationToken);

            if (department is null)
            {
                throw new ArgumentNullException();
            }

            return department;
        }
    }
}
