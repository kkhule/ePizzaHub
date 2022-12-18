using DataModel.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePizzaHub.Api.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (FileNotFoundException ex)
            {
                var error = new ErrorDetail() { StatusCode = StatusCodes.Status404NotFound, Message = ex.Message };
                await HandleExceptionAsync(context, error);
            }
            catch (System.Exception ex)
            {
                var error = new ErrorDetail() { StatusCode = StatusCodes.Status500InternalServerError, Message = ex.Message };
                await HandleExceptionAsync(context, error);
            }
        }


        public async Task HandleExceptionAsync(HttpContext context, ErrorDetail error)
        {
            context.Response.StatusCode = error.StatusCode;
            await context.Response.WriteAsync(error.ToString());
        }
    }
}
