namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Commands.CreateSupplier
{
    using FluentValidation;

    public class CreateSupplierCommandValidator:  AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}