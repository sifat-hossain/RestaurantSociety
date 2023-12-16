using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using Spread.Connect.Domain.Framework;
using Spread.Connect.Identity.Extensions;

namespace Spread.Connect.Domain.Framework.Pipeline;

public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
{
    private readonly ILogger _logger;
    private readonly IIdentityContext _identityContext;

    public RequestLogger(ILogger<TRequest> logger,
        IIdentityContext identityContext)
    {
        _logger = logger;
        _identityContext = identityContext;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        string name = typeof(TRequest).Name;

        _logger.LogInformation("Request: {0} Payload: {1} User: {2}", name, JsonConvert.SerializeObject(request,
            new JsonSerializerSettings
            {
                ContractResolver = new LoggingPropertiesResolver()
            }), _identityContext.UserId);

        return Task.CompletedTask;
    }
}
