using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spread.Connect.Domain.Entities;
using Spread.Connect.Domain.Framework.Interfaces;

namespace Spread.Connect.Domain.Framework.Services;

/// <summary>
/// Service used to get entities that need to be synced
/// </summary>
public class HistoryService : IHistoryService
{
    /// <summary>
    /// The core database context
    /// </summary>
    private readonly IHistoryDbContext _historyDbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="HistoryService"/> class.
    /// </summary>
    /// <param name="historyDbContext">The core database context.</param>
    public HistoryService(IHistoryDbContext historyDbContext)
    {
        _historyDbContext = historyDbContext;
    }

    /// <summary>Gets the entities to pull asynchronous.</summary>
    /// <typeparam name="T">The type of entity to pull</typeparam>
    /// <param name="lastSync">The last synchronize date time.</param>
    /// <param name="skip">The numebr of records to skip.</param>
    /// <param name="take">The number of records to take.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An instance of SyncEntityWithHistory<typeparamref name="T"/></returns>
    public Task<List<SyncEntityWithHistory<T>>> GetEntitiesToPullAsync<T>(DateTime lastSync, int skip, int take, CancellationToken cancellationToken)
        where T : MobileSynchronisationEntity
    {
        Task<List<SyncEntityWithHistory<T>>> c = _historyDbContext.Set<T>()
            .Where(p => EF.Property<DateTime>(p, "PeriodStart") > lastSync)
            .Skip(skip)
            .Take(take)
            .Select(e => new SyncEntityWithHistory<T>
            {
                Entity = e,
                PeriodStart = EF.Property<DateTime>(e, "PeriodStart"),
                PeriodEnd = EF.Property<DateTime>(e, "PeriodEnd")
            })
            .ToListAsync(cancellationToken);
        return c;
    }

    /// <summary>Gets the entities to pull asynchronous.</summary>
    /// <typeparam name="T">The type of entity to pull</typeparam>
    /// <param name="predicate">The predicate.</param>
    /// <param name="lastSync">The last synchronize.</param>
    /// <param name="skip">The skip.</param>
    /// <param name="take">The take.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    public Task<List<SyncEntityWithHistory<T>>> GetEntitiesToPullAsync<T>(Expression<Func<T, bool>> predicate, DateTime lastSync, int skip, int take, CancellationToken cancellationToken)
        where T : MobileSynchronisationEntity
    {
        return _historyDbContext.Set<T>()
            .Where(p => EF.Property<DateTime>(p, "PeriodStart") > lastSync)
            .Where(predicate)
            .Skip(skip)
            .Take(take)
            .Select(e => new SyncEntityWithHistory<T>
            {
                Entity = e,
                PeriodStart = EF.Property<DateTime>(e, "PeriodStart"),
                PeriodEnd = EF.Property<DateTime>(e, "PeriodEnd")
            })
            .ToListAsync(cancellationToken);
    }

    /// <summary>Gets the synchronize values from entity.</summary>
    /// <typeparam name="T">The type of entity</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>An instance of SyncEntityWithHistory<typeparamref name="T"/></returns>
    public SyncEntityWithHistory<T> GetSyncValuesFromEntity<T>(T entity)
        where T : MobileSynchronisationEntity
    {
        return new SyncEntityWithHistory<T>
        {
            Entity = entity,
            PeriodStart = _historyDbContext.Entry(entity)
                .Property<DateTime>("PeriodStart").CurrentValue,
            PeriodEnd = _historyDbContext.Entry(entity)
                .Property<DateTime>("PeriodEnd").CurrentValue
        };
    }
}
