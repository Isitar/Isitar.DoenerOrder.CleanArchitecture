namespace Isitar.DoenerOrder.CleanArchitecture.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using NodaTime;

    public class Ingredient : IAuditableEntity
    {
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
        public string Name { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public decimal AdditionalPrice { get; set; }
    }
}