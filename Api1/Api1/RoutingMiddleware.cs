using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();

            if(path == "/" || path == "/index")
            {
                await context.Response.WriteAsync("<h1>Добро пожаловать!</h1>");
            }
            else if(path == "/about")
            {
                await context.Response.WriteAsync("<h1>О нас</h1>");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
