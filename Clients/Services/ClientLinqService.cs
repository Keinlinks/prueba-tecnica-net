using Clients.Entities;
using Clients.Dtos;
using Clients.Repositories;
using Microsoft.Extensions.Logging;

namespace Clients.Services
{
    public class ClientLinqService
    {
        readonly IClientRepository ClientRepository;
        readonly ILogger<ClientLinqService> Logger;

        public ClientLinqService(IClientRepository clientRepository, ILogger<ClientLinqService> logger)
        {
            ClientRepository = clientRepository;
            Logger = logger;
        }
        public async Task<PaginationDto<ClientDto>> GetClients(int page, int pageSize)
        {
            Logger.LogInformation("Fetching clients using LINQ: Page {Page}, PageSize {PageSize}", page, pageSize);
            try
            {
                List<Client> client = await ClientRepository.GetWithLinq(page, pageSize);
                int totalClients = await ClientRepository.GetTotalClientsCount();
                List<ClientDto> clientDtos = client.Select(c => new ClientDto
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Country = c.Country.Name,
                    Phone = c.Phone
                }).ToList();
                return new PaginationDto<ClientDto>(page, pageSize, totalClients,clientDtos);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while fetching clients using LINQ: Page {Page}, PageSize {PageSize}", page, pageSize);
                throw;
            }
        }

    }
}
