using FluentValidation;

namespace ApplicationLayer.Operations.Common.Organization.Commands.Delete
{
    internal class DeleteOrganizationCommandValidator
        : AbstractValidator<DeleteOrganizationCommand>
    {
        public DeleteOrganizationCommandValidator()
        {
            RuleFor(x => x.OrganizationId).NotEmpty();
        }
    }
}
