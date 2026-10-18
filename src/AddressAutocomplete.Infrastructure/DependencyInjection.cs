using AddressAutocomplete.Application.Services;
using AddressAutocomplete.Infrastructure.AzureMaps;
using AddressAutocomplete.Infrastructure.AzureMaps.Services;
using AddressAutocomplete.Infrastructure.Persistence;
using AddressAutocomplete.Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddressAutocomplete.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureMapsOptions>(configuration.GetSection(AzureMapsOptions.SectionName));
        //services.Configure<AzureMapsOptions>(options => 
            //configuration.GetSection(AzureMapsOptions.SectionName).Bind(options));


        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

        services.AddHttpClient<IAddressSearchService, AzureMapsAddressSearchService>();

        services.AddScoped<IAddressPersistenceService, AddressPersistenceService>();

        return services;
    }
}