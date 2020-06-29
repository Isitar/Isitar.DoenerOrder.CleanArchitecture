namespace Isitar.DoenerOrder.CleanArchitecture.Application.Suppliers.Commands.CreateSupplier
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;

    public class CreateSupplierCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}