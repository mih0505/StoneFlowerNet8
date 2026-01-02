using FluentValidation;

namespace ApplicationLayer.Operations.Common.Organization.Commands.Create
{
    internal class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
    {
        public CreateOrganizationCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);
        }
    }
}
