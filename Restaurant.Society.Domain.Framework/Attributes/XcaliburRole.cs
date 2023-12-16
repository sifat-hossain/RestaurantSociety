using System;
using System.Collections.Generic;

namespace Restaurant.Society.Domain.Framework.Attributes;

public class SpreadRole : Attribute
{
    internal readonly IList<string> _roles;

    public SpreadRole(params string[] roles)
    {
        _roles = new List<string>();

        for (int i = 0; i < roles.Length; i++)
        {
            _roles.Add(roles[i]);
        }
    }
}
