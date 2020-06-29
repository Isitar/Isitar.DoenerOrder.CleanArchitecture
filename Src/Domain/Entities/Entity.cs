namespace Isitar.DoenerOrder.CleanArchitecture.Domain.Entities
{
    using System;

    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}