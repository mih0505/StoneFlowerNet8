using MediatR;

namespace ApplicationLayer.Operations.Common.Department.Commands.Delete
{
    internal class DeleteDepartmentCommand : IRequest<Unit>
    {
        public Guid DepartmentId { get; set; }
    }
}
