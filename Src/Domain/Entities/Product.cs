namespace Isitar.DoenerOrder.CleanArchitecture.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using NodaTime;

    public class Product : IAuditableEntity
    {
        public Product() : base()
        {
            Ingredients= new HashSet<Ingredient>();
        }
        
        public string Name { get; set; }

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public decimal BasePrice { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; private set; }
        
        
        #region IAuditableEntity

        public Guid Id { get; set; }
        public User CreatedBy { get; set; }
        public Guid? CreatedById { get; set; }
        public Instant? CreatedAt { get; set; }
        public User UpdatedBy { get; set; }
        public Guid? UpdatedById { get; set; }
        public Instant? UpdatedAt { get; set; }
        public ICollection<AuditTrailEntry> AuditTrailEntries { get; } = new HashSet<AuditTrailEntry>();

        #endregion
    }
}