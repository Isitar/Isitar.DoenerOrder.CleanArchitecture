namespace Isitar.DoenerOrder.CleanArchitecture.Persistence
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Common;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class DoenerDbContext : DbContext, IDoenerDbContext
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IInstant instant;

        public DoenerDbContext(ICurrentUserService currentUserService, IInstant instant, DbContextOptions<DoenerDbContext> options) : base(options)
        {
            this.currentUserService = currentUserService;
            this.instant = instant;
        }

        public DbSet<BulkOrder> BulkOrders { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }


        /// <summary>
        /// Serializes an object using Newtonsoft JSON
        /// Handles referece loop etc.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedById = currentUserService.UserId;
                        entry.Entity.CreatedAt = instant.Now;

                        entry.Entity.AuditTrailEntries.Add(new AuditTrailEntry
                        {
                            When = instant.Now,
                            OldValue = "",
                            NewValue = SerializeObject(entry.Entity),
                        });
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedById = currentUserService.UserId;
                        entry.Entity.UpdatedAt = instant.Now;
                        var changedProperties = entry.Properties.Where(p => p.IsModified).ToList();
                        if (changedProperties.Count > 0)
                        {
                            var (from, to) = changedProperties.Aggregate((From: new Dictionary<string, object>(), To: new Dictionary<string, object>()), (carry, p) =>
                            {
                                if (!p.IsModified)
                                {
                                    return carry;
                                }

                                carry.From.Add(p.Metadata.Name, p.OriginalValue);
                                carry.To.Add(p.Metadata.Name, p.CurrentValue);
                                return carry;
                            });


                            entry.Entity.AuditTrailEntries.Add(new AuditTrailEntry
                            {
                                When = instant.Now,
                                OldValue = SerializeObject(from),
                                NewValue = SerializeObject(to),
                            });
                        }

                        break;
                    case EntityState.Deleted:
                        entry.Entity.AuditTrailEntries.Add(new AuditTrailEntry
                        {
                            When = instant.Now,
                            OldValue = SerializeObject(entry.Entity),
                            NewValue = "",
                        });
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoenerDbContext).Assembly);
        }
    }
}