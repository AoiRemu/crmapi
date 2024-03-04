using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CRM.Attributes
{
    public class AuthFilter : Attribute, IActionFilter
    {
        private IConfiguration _configuration;

        public AuthFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //if(context.ActionDescriptor.FilterDescriptors.Any(a=> a.Filter.GetType() == AllowAnonymousAttribute))
            //var token = context.HttpContext.Request.Headers.Authorization;
            //if(string.IsNullOrEmpty(token) )
            //{
            //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //    context.Result = new ContentResult();
            //}
        }
    }
}
