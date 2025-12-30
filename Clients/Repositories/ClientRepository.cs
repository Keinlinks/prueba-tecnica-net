
using Clients.Dtos;
using Clients.Entities;

namespace Clients.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public List<ClientDto> GetWithEF()
        {
            throw new NotImplementedException();
        }

        public List<ClientDto> GetWithLinq()
        {
            throw new NotImplementedException();
        }
    }
}
