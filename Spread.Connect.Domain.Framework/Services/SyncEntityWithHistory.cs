using System;
using Spread.Connect.Domain.Entities;

namespace Spread.Connect.Domain.Framework.Services;

/// <summary>
/// The response from a pull request
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class SyncEntityWithHistory<TEntity> where TEntity : MobileSynchronisationEntity
{
    /// <summary>Gets or sets the entity.</summary>
    /// <value>The entity.</value>
    public TEntity Entity { get; set; }

    /// <summary>Gets or sets the period start.</summary>
    /// <value>The period start.</value>
    public DateTime PeriodStart { get; set; }

    /// <summary>Gets or sets the period end.</summary>
    /// <value>The period end.</value>
    public DateTime PeriodEnd { get; set; }
}
