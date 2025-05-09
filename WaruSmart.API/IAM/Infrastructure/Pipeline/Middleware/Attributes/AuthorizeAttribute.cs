using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WaruSmart.API.IAM.Domain.Model.Aggregates;

namespace WaruSmart.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute: Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            return;
        }
        var user = (User?)context.HttpContext.Items["User"];
        if (user is null) context.Result = new UnauthorizedResult();
    }
}