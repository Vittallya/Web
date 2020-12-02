using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1
{
    public class TokenMW
    {
        private RequestDelegate _next;
        private readonly string _token;

        public TokenMW(RequestDelegate next, string token)
        {
            _next = next;
            _token = token;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //await context.Response.WriteAsync("It`s working!");

            var token = context.Request.Query["token"];

            if (token != _token)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync($"Your token is not equal to {_token}");
            }
            else
            {
                _next?.Invoke(context);
            }
        }
    }
}
