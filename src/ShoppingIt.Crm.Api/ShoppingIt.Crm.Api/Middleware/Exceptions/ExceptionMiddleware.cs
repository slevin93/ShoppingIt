// <copyright file="ExceptionMiddleware.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Api.Middleware.Exceptions
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// This class will handle all exceptions thrown in the application and map the response to the client.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The request delegate.</param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invoke the next middleware piple line.
        /// </summary>
        /// <param name="httpContext">The http context.</param>
        /// <returns>Returns <see cref="Task"/>.</returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (Exception ex)
            {
                await this.HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Handles any exceptions thrown in the system.
        /// </summary>
        /// <param name="context">The http context.</param>
        /// <param name="exception">The exception thrown.</param>
        /// <returns>Returns <see cref="Task"/>.</returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"{exception.Message} :: {exception?.InnerException?.Message}",
            }.ToString());
        }
    }
}
