namespace Isitar.DoenerOrder.CleanArchitecture.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Application.Suppliers.Commands.CreateSupplier;
    using Application.Suppliers.Commands.UpdateSupplier;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class SupplierController : ApiController
    {
        [HttpPost("/supplier")]
        public async Task<ActionResult> InsertSupplier()
        {
            
            
            await Mediator.Send(new CreateSupplierCommand
            {
                Id = Guid.NewGuid(),
                Name = "Test",
            });
            return Ok();
        }
        
        [HttpPatch("/supplier/{id}")]
        public async Task<ActionResult> UpdateSupplier(Guid id)
        {
            
            
            await Mediator.Send(new UpdateSupplierCommand
            {
                Id = id,
                Name = "Test neu",
            });
            return Ok();
        }
    }
}