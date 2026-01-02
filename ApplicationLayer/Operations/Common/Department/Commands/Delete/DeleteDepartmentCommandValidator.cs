using FluentValidation;

namespace ApplicationLayer.Operations.Common.Department.Commands.Delete
{
    internal class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator()
        {
            RuleFor(x => x.DepartmentId).NotEmpty();
        }
    }
}
