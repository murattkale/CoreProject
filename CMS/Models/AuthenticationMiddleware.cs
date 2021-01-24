using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


public class AuthenticationMiddleware
{
    RequestDelegate _next;
    IHttpContextAccessor _IHttpContextAccessor;

    public AuthenticationMiddleware(
        RequestDelegate next,
        IHttpContextAccessor _IHttpContextAccessor
        )
    {
        this._next = next;
        this._IHttpContextAccessor = _IHttpContextAccessor;
    }

    public Task Invoke(HttpContext httpContext)
    {
        if (SessionRequest._User == null)
        {
            //_IHttpContextAccessor.HttpContext.Session.Set("_user", _user);
        }

        return _next(httpContext);
    }
}

public static class AuthenticationMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthenticationMiddleware>();
    }
}
