using Newtonsoft.Json;

namespace Spread.Connect.Domain.Framework.Exceptions;

public class ForbiddenException : Exception
{
    public ForbiddenException(string action, object payload)
        : base($"Action \"{action}\" with paylaod ({JsonConvert.SerializeObject(payload)}) was attempted.")
    {

    }

    public ForbiddenException()
    {
    }

    public ForbiddenException(string message) : base(message)
    {
    }

    public ForbiddenException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
