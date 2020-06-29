namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Commands.UpdateSupplier
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand>
    {
        private readonly IDoenerDbContext dbContext;

        public UpdateSupplierCommandHandler(IDoenerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await dbContext.Suppliers.FirstAsync(p => p.Id.Equals(request.Id), cancellationToken: cancellationToken);
            supplier.Name = request.Name;

            await dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}