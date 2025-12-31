
using Clients.Entities;

namespace Clients.Repositories
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetWithLinq(int page, int pageSize);
        public Task<List<Client>> GetWithStoreProcedure(int page, int pageSize);
        public Task<int> GetTotalClientsCount();
    }
}
