using System;

namespace Spread.Connect.Domain;

public interface IDateTime
{
    DateTime UtcNow { get; }
    DateTime MinDate { get; }
    DateTime MaxDate { get; }
}
