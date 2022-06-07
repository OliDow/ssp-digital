namespace Ssp.Digital.Meter.Api.Middleware.UseUser;

public class UserAttribute : GlobalStateAttribute
{
    public UserAttribute()
        : base(UserMiddleware.UserContextData)
    {
    }
}