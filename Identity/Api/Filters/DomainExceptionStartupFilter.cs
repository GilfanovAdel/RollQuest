using Api.Middlewares;

namespace Api.Filters;

public class DomainExceptionStartupFilter :IStartupFilter
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return builder =>
        {
            builder.UseMiddleware<DomainExceptionMiddleware>();
            next(builder);
        };
    }
}