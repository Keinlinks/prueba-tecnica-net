
using Clients.Entities;

namespace Clients.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public List<Client> GetWithEF()
        {
            throw new NotImplementedException();
        }

        public List<Client> GetWithLinq()
        {
            throw new NotImplementedException();
        }
    }
}
