namespace Isitar.DoenerOrder.CleanArchitecture.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NodaTime;

    public class Order : IAuditableEntity
    {
        public Order() : base()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid BulkOrderId { get; set; }
        public virtual BulkOrder BulkOrder { get; set; }

        public bool IsPaid { get; set; }

        public decimal Price => OrderLines.Sum(ol => ol.Ingredient.AdditionalPrice) + Product.BasePrice;

        public virtual ICollection<OrderLine> OrderLines { get; }
        
        
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