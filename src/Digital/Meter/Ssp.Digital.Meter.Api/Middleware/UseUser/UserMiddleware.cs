using HotChocolate.Resolvers;
using Ssp.Digital.Meter.Api.Models;
using System.Security.Claims;

namespace Ssp.Digital.Meter.Api.Middleware.UseUser;

public class UserMiddleware
{
    public const string UserContextData = "User";

    private readonly FieldDelegate _next;

    public UserMiddleware(FieldDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    /// <summary>
    /// Invokes the specified context.
    /// Use this after the Authentication Middleware as it will need the claimsPrincipal of the user.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task Invoke(IMiddlewareContext context)
    {
        if (context.ContextData.TryGetValue("ClaimsPrincipal", out var rawClaimsPrincipal) &&
            rawClaimsPrincipal is ClaimsPrincipal claimsPrincipal)
        {
            User user = new()
            {
                Id = "IDTest",
                Email = "EmailTest@test.com",
                Username = null,
                EmailVerified = true
            };

            context.ContextData.Add(UserContextData, user);
        }

        await _next(context);
    }
}