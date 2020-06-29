namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Queries.SupplierDetail
{
    using FluentValidation;

    public class SupplierDetailQueryValidator : AbstractValidator<SupplierDetailQuery>
    {
        public SupplierDetailQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}