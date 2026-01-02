using FluentValidation;

namespace ApplicationLayer.Operations.Common.Organization.Queries.GetOrganizationById
{
    internal class GetOrganizationByIdValidator : AbstractValidator<GetOrganizationByIdQuery>
    {
        public GetOrganizationByIdValidator()
        {
            RuleFor(query => query.Id)
                .NotEmpty();
        }
    }
}
