using FluentValidation;

namespace WebApiSample.ModelOperations.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(cmd => cmd.Model.Name).MinimumLength(2)
                                        .NotEmpty()
                                        .NotNull();
            RuleFor(cmd => cmd.Model.Surname).MinimumLength(2)
                                            .NotEmpty()
                                            .NotNull();
        }
    }
}