using System;

namespace Restaurant.Society.Domain.Digital.Menu;

public interface IDateTime
{
    DateTime UtcNow { get; }
    DateTime MinDate { get; }
    DateTime MaxDate { get; }
}
