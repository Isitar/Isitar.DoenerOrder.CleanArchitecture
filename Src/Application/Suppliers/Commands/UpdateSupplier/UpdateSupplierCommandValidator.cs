namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Commands.UpdateSupplier
{
    using System.Linq;
    using Common.Interfaces;
    using FluentValidation;

    public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierCommandValidator(IDoenerDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Must(id => dbContext.Suppliers.Any(s => s.Id.Equals(id)))
                .WithMessage("Supplier does not exist");

            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}