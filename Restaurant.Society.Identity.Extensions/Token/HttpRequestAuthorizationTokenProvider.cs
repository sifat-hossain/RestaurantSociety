﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Spread.Connect.Domain.Constants;

namespace Restaurant.Society.Identity.Extensions.Token;

public class HttpRequestAuthorizationTokenProvider : IAuthorizationTokenProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IHeaderDictionary RequestHeaders => _httpContextAccessor.HttpContext.Request.Headers;

    public HttpRequestAuthorizationTokenProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public (bool, IAuthorizationToken) TryGet()
    {
        if (_httpContextAccessor?.HttpContext?.Request == null)
            return (false, null);

        if (!RequestHeaders.TryGetValue(Constants.Keys.Authorization, out StringValues values)
            || values.Count != 1)
            return (false, null);

        string[] authHeader = values[0].Split(' ');

        if (authHeader.Length != 2)
            return (false, null);

        string authType = authHeader[0];
        string authToken = authHeader[1];

        if (!authType.Equals(Constants.Keys.Bearer)
            || string.IsNullOrWhiteSpace(authToken))
            return (false, null);

        IAuthorizationToken token = new AuthorizationToken(authType, authToken);
        return (true, token);
    }
}
