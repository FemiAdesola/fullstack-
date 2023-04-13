using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Authorization
{
    public class UpdateUserRequirement : IAuthorizationRequirement { }

    public class UpdateUserPermission : AuthorizationHandler<UpdateUserRequirement, int>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            UpdateUserRequirement requirement,
            int resource
        )
        {
            Console.WriteLine("conext resource : " + context.Resource);
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
            }
            else if (userId == resource.ToString())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
