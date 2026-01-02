using FluentValidation;

namespace ApplicationLayer.Operations.Common.Department.Commands.Create
{
    internal class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(command => command.Code)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20);

            RuleFor(command => command.Organization)
                .NotNull();

            RuleFor(command => command.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);

            RuleFor(command => command.City)                
                .MaximumLength(128);

            RuleFor(command => command.Street)                
                .MaximumLength(128);

            RuleFor(command => command.House)                
                .MaximumLength(128);

            RuleFor(command => command.Float)
                .GreaterThan(0);

            RuleFor(command => command.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15);

            RuleFor(command => command.AdvancedPhoneNumber)                
                .MaximumLength(15);

            RuleFor(command => command.Email)
                .EmailAddress()
                .MaximumLength(128);
        }
    }
}
