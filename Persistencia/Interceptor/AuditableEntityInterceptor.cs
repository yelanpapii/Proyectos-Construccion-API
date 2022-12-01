using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectosConstruccion.Persistencia.Interceptor
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            if (context is null) return base.SavingChangesAsync(eventData, result, cancellationToken);

            IEnumerable<EntityEntry<IAuditableEntity>> entries = context.ChangeTracker.Entries<IAuditableEntity>();

            foreach (var entity in entries)
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Property(x => x.CreatedOn).CurrentValue = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entity.Property(x => x.ModifiedOn).CurrentValue = DateTime.UtcNow;
                        break;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}