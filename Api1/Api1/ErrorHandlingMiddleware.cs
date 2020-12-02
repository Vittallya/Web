using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1
{
    public class ErrorHandlingMiddleware
    {
        RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);

            if(context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("<h2 align=center>Вы не авторизованы, доступ к этой странице запрещен</h2>");
            }
            else if(context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync("<h2 align=center>Данная страница не найдена</h2>");
            }
        }
    }
}
