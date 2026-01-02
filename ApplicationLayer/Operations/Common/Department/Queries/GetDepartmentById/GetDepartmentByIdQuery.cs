using MediatR;

namespace ApplicationLayer.Operations.Common.Department.Queries.GetDepartmentById
{
    internal class GetDepartmentByIdQuery : IRequest<Domain.Common.Department>
    {
        public Guid Id { get; set; }
    }
}
