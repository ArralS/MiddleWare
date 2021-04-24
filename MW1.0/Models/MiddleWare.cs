using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MW1._0.Models
{
    public class MiddleWare
    {
      
        private RequestDelegate _next;
        public MiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var x = context.Request.Headers["User-Agent"][0].ToLower();

            if (x.Contains("edge") || x.Contains("edg/") || x.Contains("trident"))
            {

                return context.Response.WriteAsync("Przegladarka nie jest obslugiwana");

            }
            else return _next(context);

        }
    }
}
