namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Commands.CreateSupplier
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using Domain.Entities;
    using MediatR;

    internal class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand>
    {
        private readonly IDoenerDbContext dbContext;

        public CreateSupplierCommandHandler(IDoenerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            await dbContext.Suppliers.AddAsync(new Supplier
            {
                Id = request.Id,
                Name = request.Name,
            });
            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}