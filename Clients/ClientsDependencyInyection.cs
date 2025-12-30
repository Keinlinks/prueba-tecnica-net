using Clients.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Clients
{
    public static class ClientsDependencyInyection
    {
        public static IServiceCollection AddClientsServices(this IServiceCollection services)
        {
            services.AddScoped<ClientsEFService>();
            services.AddScoped<ClientLinqService>();

            return services;
        }
    }
}
