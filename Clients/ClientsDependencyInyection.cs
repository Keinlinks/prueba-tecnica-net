using Clients.Repositories;
using Clients.Services;
using Microsoft.Extensions.DependencyInjection;
namespace Clients
{
    public static class ClientsDependencyInyection
    {
        public static IServiceCollection AddClientsServices(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepositoryImpl>();
            services.AddScoped<ClientsStoreProcedureService>();
            services.AddScoped<ClientLinqService>();

            return services;
        }
    }
}
