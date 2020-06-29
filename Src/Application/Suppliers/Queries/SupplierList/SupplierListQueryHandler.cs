namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Queries.SupplierList
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class SupplierListQueryHandler : IRequestHandler<SupplierListQuery, SupplierListVm>
    {
        private readonly IDoenerDbContext dbContext;
        private readonly IMapper mapper;

        public SupplierListQueryHandler(IDoenerDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<SupplierListVm> Handle(SupplierListQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await dbContext.Suppliers
                .ProjectTo<SupplierSlimDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new SupplierListVm
            {
                Suppliers = suppliers
            };
        }
    }
}