using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using POSERPAPI.Entities.Response;
using System;
using System.Net;

namespace POSERPAPI.Manager.Helper
{
    public  class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpContext httpContext = context.HttpContext;
            if(httpContext.Request.Headers!=null)
            {

            }
            var innerexception = context.Exception.InnerException != null ? context.Exception.InnerException.ToString() : string.Empty;
            var errorResponse = new ErrorResponse
            {
                Messages = new[] {"An Internal error occurred. Please Try it again.",context.Exception.Message ,innerexception
               ,context.Exception.StackTrace }
            };
            context.Result = new ObjectResult(errorResponse);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.ExceptionHandled = true;
            
            //throw new NotImplementedException();
        }
    }
}
