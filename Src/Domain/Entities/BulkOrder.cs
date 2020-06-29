namespace Isitar.DoenerOrder.CleanArchitecture.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using NodaTime;

    public class BulkOrder : IAuditableEntity
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

        public BulkOrder() : base()
        {
            Orders = new HashSet<Order>();
        }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Instant Deadline { get; set; }

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Order> Orders { get; }
    }
}