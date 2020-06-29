namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Queries.SupplierList
{
    using System;
    using Common.Mappings;
    using Domain.Entities;

    public class SupplierSlimDto : IMapFrom<Supplier>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}