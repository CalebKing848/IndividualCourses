using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SecurityApp.API.Filters
{
    public class ApiKeyAuthAttribute : ActionFilterAttribute
    {
        private const string CustomApiKeyParam = "X-API-Key";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var apiKey = context.HttpContext.Request.Headers.TryGetValue(CustomApiKeyParam, out var apiKeyValue);


            if(!apiKey)
            {
                context.Result = new UnauthorizedObjectResult("X-API-Key is missing in the header");
            }

            //if(apiKeyValue)
            //    context.Result = new UnauthorizedObjectResult("X-API-Key is not valid");

            //if (apiKeyValue rate )
            //         context.Result = new UnauthorizedObjectResult($"{apiKeyValue} is not valid");

            base.OnActionExecuting(context);
        }

    }
}
