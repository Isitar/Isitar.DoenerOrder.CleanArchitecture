namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Queries.SupplierDetail
{
    using System;
    using Common.Mappings;
    using Domain.Entities;

    public class SupplierDetailVm : IMapFrom<Supplier>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}