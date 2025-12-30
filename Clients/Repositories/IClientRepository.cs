
using Clients.Dtos;
using Clients.Entities;

namespace Clients.Repositories
{
    public interface IClientRepository
    {
        public List<ClientDto> GetWithLinq();
        public List<ClientDto> GetWithEF();
    }
}
