namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Queries.SupplierDetail
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using CleanArchitecture.Common.Resources;
    using Common.Exceptions;
    using Common.Interfaces;
    using MediatR;

    public class SupplierDetailQueryHandler : IRequestHandler<SupplierDetailQuery, SupplierDetailVm>
    {
        private readonly IDoenerDbContext dbContext;
        private readonly IMapper mapper;

        public SupplierDetailQueryHandler(IDoenerDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<SupplierDetailVm> Handle(SupplierDetailQuery request, CancellationToken cancellationToken)
        {
            var supplier = await dbContext.Suppliers.FindAsync(request.Id, cancellationToken);
            if (null == supplier)
            {
                throw new NotFoundException(Resources.Supplier, request.Id);
            }

            return mapper.Map<SupplierDetailVm>(supplier);
        }
    }
}