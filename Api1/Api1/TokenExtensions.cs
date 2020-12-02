using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1
{
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string token)
        {
            builder.UseMiddleware<TokenMW>(token);
            return builder;
        }

        public static void UseRoutingMiddlewareAllOfNeed(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorHandlingMiddleware>();
            builder.UseMiddleware<AutohenticationMiddleware>();
            builder.UseMiddleware<RoutingMiddleware>();

        }
    }
}
