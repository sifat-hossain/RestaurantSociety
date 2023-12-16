using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Spread.Connect.Domain.Framework.Attributes;
using Spread.Connect.Domain.Framework.Exceptions;
using Spread.Connect.Identity.Extensions;
using ValidationException = Spread.Connect.Domain.Framework.Exceptions.ValidationException;

namespace Spread.Connect.Domain.Framework.Pipeline;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly IIdentityContext _identityContext;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators,
        IIdentityContext identityContext)
    {
        _validators = validators;
        _identityContext = identityContext;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var roles = (SpreadRole)Attribute
            .GetCustomAttribute(request.GetType(), typeof(SpreadRole));

        if (roles != null
            && !_identityContext.Roles.Any(r => roles._roles.Contains(r)))
        {
            throw new ForbiddenException(nameof(request), request);
        }

        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }

        return next();
    }
}
