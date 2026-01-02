using FluentValidation;

namespace ApplicationLayer.Operations.Common.Organization.Commands.Update
{
    internal class UpdateOrganizationCommandValidator
        : AbstractValidator<UpdateOrganizationCommand>
    {
        public UpdateOrganizationCommandValidator()
        {
            RuleFor(command => command.Id)
            .NotEmpty();

            RuleFor(command => command.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);
        }
    }
}
