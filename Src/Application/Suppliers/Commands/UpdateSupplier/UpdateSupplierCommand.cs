namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Commands.UpdateSupplier
{
    using System;
    using MediatR;

    public class UpdateSupplierCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}