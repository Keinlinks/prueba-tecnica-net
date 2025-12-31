using Clients.Dtos;
using Clients.Entities;
using Clients.Repositories;
using Microsoft.Extensions.Logging;

namespace Clients.Services
{
    public class ClientsStoreProcedureService
    {
        readonly IClientRepository ClientRepository;
        readonly ILogger<ClientsStoreProcedureService> Logger;
        public ClientsStoreProcedureService(IClientRepository clientRepository, ILogger<ClientsStoreProcedureService> logger)
        {
            ClientRepository = clientRepository;
            Logger = logger;
        }

        public async Task<PaginationDto<ClientDto>> GetClients(int page, int pageSize)
        {
            Logger.LogInformation("Fetching clients using stored procedure: Page {Page}, PageSize {PageSize}", page, pageSize);
            try
            {
                List<Client> client = await ClientRepository.GetWithStoreProcedure(page, pageSize);
                int totalClients = await ClientRepository.GetTotalClientsCount();
                List<ClientDto> clientDtos = client.Select(c => new ClientDto
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Country = c.Country.Name,
                    Phone = c.Phone
                }).ToList();
                return new PaginationDto<ClientDto>(page, pageSize, totalClients, clientDtos);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error: fetching clients using store procedure: Page {Page}, PageSize {PageSize}", page, pageSize);
                throw;
            }
        }
    }
}
