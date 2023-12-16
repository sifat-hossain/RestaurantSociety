using System;
using System.Collections.Generic;

namespace Spread.Connect.Identity.Extensions;

public interface IIdentityContext
{
    Guid UserId { get; }
    Guid TenantId { get; }
    string Email { get; }
    string FirstName { get; }
    string Surname { get; }
    IEnumerable<string> Roles { get; }
    IEnumerable<string> Customers { get; }
    string AuthorizationHeader { get; }
    string AuthorizationScheme { get; }
}
