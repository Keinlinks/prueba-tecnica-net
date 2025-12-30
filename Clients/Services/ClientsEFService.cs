
using Clients.Dtos;
using Clients.Entities;
using Clients.Repositories;

namespace Clients.Services
{
    public class ClientsEFService
    {
        readonly IClientRepository ClientRepository;
        public ClientsEFService(IClientRepository clientRepository)
        {
            ClientRepository = clientRepository;
        }

        public async Task<List<ClientDto>> GetClients(int page, int pageSize)
        {
            List<Client> client = await ClientRepository.GetWithEF(page, pageSize);
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
