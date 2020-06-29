namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Queries.SupplierList
{
    using System.Collections.Generic;

    public class SupplierListVm
    {
        public IList<SupplierSlimDto> Suppliers { get; set; }
        
    }
}