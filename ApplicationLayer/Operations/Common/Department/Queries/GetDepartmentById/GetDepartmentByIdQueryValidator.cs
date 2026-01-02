using FluentValidation;

namespace ApplicationLayer.Operations.Common.Department.Queries.GetDepartmentById
{
    internal class GetDepartmentByIdQueryValidator : AbstractValidator<GetDepartmentByIdQuery>
    {
        public GetDepartmentByIdQueryValidator()
        {
            RuleFor(query => query.Id)
                .NotEmpty();
        }
    }
}
