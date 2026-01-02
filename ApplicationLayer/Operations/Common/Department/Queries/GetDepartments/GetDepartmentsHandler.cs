using ApplicationLayer.Infrastructure;
using ApplicationLayer.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Operations.Common.Department.Queries.GetDepartments
{
    internal class GetDepartmentsHandler : RequestHandlerBase<GetDepartmentsQuery, List<DepartmentDTO>>
    {
        public GetDepartmentsHandler(IStoneFlowersDbContext context, IMapper mapper)
        : base(context, mapper)
        { }

        public override async Task<List<DepartmentDTO>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await db.Departments
                .Where(dep => !dep.IsDeleted)
                .OrderBy(dep => dep.Name)
                .ProjectTo<DepartmentDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return departments;
        }
    }
}
