using HotChocolate.Types.Descriptors;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Ssp.Digital.Meter.Api.Middleware.UseUser;

public class UseUserAttribute : ObjectFieldDescriptorAttribute
{
    // Orders middleware by the caller line Number on the Attribute.
    public UseUserAttribute([CallerLineNumber] int order = 0)
    {
        Order = order;
    }

    // Run middleware
    public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
    {
        descriptor.Use<UserMiddleware>();
    }
}