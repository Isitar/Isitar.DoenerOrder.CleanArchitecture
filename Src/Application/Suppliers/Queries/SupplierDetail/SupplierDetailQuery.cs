namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Queries.SupplierDetail
{
    using System;
    using MediatR;

    public class SupplierDetailQuery : IRequest<SupplierDetailVm>
    {
        public Guid Id { get; set; }
    }
}