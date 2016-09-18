using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace SimpleERP.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class EtagMiddleware
    {
        private readonly RequestDelegate _next;

        public EtagMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;
                var request = httpContext.Request;

                var key = GetKey(request);
                var keyBytes = Encoding.UTF8.GetBytes(key);

                // request body
                if (request.Body.CanSeek)
                {
                    request.Body.Position = 0;
                }
                var input = new StreamReader(request.Body).ReadToEnd();
                var contentBytes = Encoding.UTF8.GetBytes(input);

                var combinedBytes = Combine(keyBytes, contentBytes);
                var ETag = GenerateETag(combinedBytes);

                if (httpContext.Request.Method == "GET")
                {
                    if (httpContext.Request.Headers.Keys.Contains("If-None-Match") && httpContext.Request.Headers["If-None-Match"].ToString() == ETag)
                    {
                        // not modified
                        httpContext.Response.StatusCode = 304;
                        return Task.FromResult(0);
                    }

                    httpContext.Response.Headers.Add("ETag", new[] { ETag });
                }

                return Task.FromResult(0);
            }, context);

            //Once everything unwinds the OnStarting should get called and we can then record the Etag.
            await _next(context);
        }

        private string GenerateETag(byte[] data)
        {
            string ret = string.Empty;

            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(data);
                string hex = BitConverter.ToString(hash);
                ret = hex.Replace("-", "");
            }

            return ret;
        }

        private byte[] Combine(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            System.Buffer.BlockCopy(a, 0, c, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }

        private static string GetKey(HttpRequest request)
        {
            return request.Path.ToString();
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class EtagMiddlewareExtensions
    {
        public static IApplicationBuilder UseEtagMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EtagMiddleware>();
        }
    }
}