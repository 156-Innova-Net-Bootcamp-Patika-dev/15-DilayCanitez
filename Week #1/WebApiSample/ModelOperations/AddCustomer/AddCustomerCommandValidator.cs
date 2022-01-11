using FluentValidation;

namespace WebApiSample.ModelOperations.AddCustomer
{
    public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotNull()
                                                .NotEmpty()
                                                .MinimumLength(2);
            RuleFor(cmd => cmd.Model.Email).EmailAddress();
            RuleFor(cmd => cmd.Model.Surname).NotEmpty()
                                            .NotNull()
                                            .MinimumLength(2);
        }
    }
}