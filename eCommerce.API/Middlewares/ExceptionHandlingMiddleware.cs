﻿using System.Net;

namespace eCommerce.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                _logger.LogError($"exception type: {ex.GetType().ToString()} : {ex.Message}");

                if(ex.InnerException is not null)
                {
                    _logger.LogError($"Inner exception type: {ex.InnerException.GetType()} : {ex.InnerException.Message}");
                }
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;  
                await httpContext.Response.WriteAsJsonAsync(new {Message = ex.Message , Type = ex.GetType().ToString()});
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
