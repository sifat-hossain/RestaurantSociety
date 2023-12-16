﻿namespace Restaurant.Society.Identity.Extensions.Token;

public interface IAuthorizationTokenProvider
{
    (bool, IAuthorizationToken) TryGet();
}
