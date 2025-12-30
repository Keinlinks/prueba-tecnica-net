using Clients.Entities;
using Clients.Dtos;
using Clients.Repositories;

namespace Clients.Services
{
    public class ClientLinqService
    {
        readonly IClientRepository ClientRepository;
        public ClientLinqService(IClientRepository clientRepository)
        {
            ClientRepository = clientRepository;
        }
        public async Task<List<ClientDto>> GetClients(int page, int pageSize)
        {
            List<Client> client = await ClientRepository.GetWithLinq(page, pageSize);
            List<ClientDto> clientDtos = client.Select(c => new ClientDto
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                Country = c.Country.Name,
                Phone = c.Phone
            }).ToList();

            return clientDtos;
        }

    }
}
