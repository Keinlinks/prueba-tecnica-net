
using Clients.Entities;

namespace Clients.Repositories
{
    public interface IClientRepository
    {
        public List<Client> GetWithLinq();
        public List<Client> GetWithEF();
    }
}
