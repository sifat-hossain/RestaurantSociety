using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Spread.Connect.Identity.Extensions;

namespace Spread.Connect.Domain.Framework.Pipeline;

public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;
    private readonly IIdentityContext _identityContext;

    public RequestPerformanceBehaviour(ILogger<TRequest> logger,
        IIdentityContext identityContext)
    {
        _timer = new Stopwatch();

        _logger = logger;
        _identityContext = identityContext;
    }

    public async Task<TResponse> Handle(TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        _timer.Start();

        TResponse response = await next().ConfigureAwait(false);

        _timer.Stop();

        if (_timer.ElapsedMilliseconds > 500)
        {
            string name = typeof(TRequest).Name;

            _logger.LogWarning("Long Running Request: ({ElapsedMilliseconds} milliseconds) {@Request} User: {userId} RequestName: {name}",
                 _timer.ElapsedMilliseconds, JsonConvert.SerializeObject(request,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new LoggingPropertiesResolver()
                    }), _identityContext.UserId, name);
        }

        return response;
    }
}
