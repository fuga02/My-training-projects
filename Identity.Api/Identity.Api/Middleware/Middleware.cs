﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Identity.Api.Middleware;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class Middleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger<Middleware> _logger; 

    public Middleware(RequestDelegate next, ILogger<Middleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
           await  _next(httpContext);
        }
        catch (Exception e)
        {

            _logger.LogError(e, "InternalError");

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            httpContext.Response.WriteAsJsonAsync(new
            {
                Message = e.Message,
            });
        }


        /*return _next(httpContext);*/
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<Middleware>();
    }
}