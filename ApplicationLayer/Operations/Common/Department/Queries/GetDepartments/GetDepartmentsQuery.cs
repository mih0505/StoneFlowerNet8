using MediatR;

namespace ApplicationLayer.Operations.Common.Department.Queries.GetDepartments
{
    public class GetDepartmentsQuery : IRequest<List<DepartmentDTO>>
    { }
}
