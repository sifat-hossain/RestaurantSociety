using Newtonsoft.Json.Serialization;
using Restaurant.Society.Domain.Framework.Attributes;
using System.Reflection;

namespace Restaurant.Society.Domain.Framework;

public class LoggingPropertiesResolver : DefaultContractResolver
{
    protected override List<MemberInfo> GetSerializableMembers(Type objectType)
    {
        return objectType.GetProperties()
                         .Where(pi => !Attribute.IsDefined(pi, typeof(SensitiveData)))
                         .ToList<MemberInfo>();
    }
}
