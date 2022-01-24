using ELN.Elasticsearch.API.Services;

namespace ELN.Elasticsearch.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IPeopleService, PeopleService>();

        return services;
    }
}
