using Scheduling.APIs;

namespace Scheduling;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IMeetingsService, MeetingsService>();
    }
}
