using Clients.Db;
using Clients.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Clients.Dtos;
namespace Clients.Repositories
{
    internal class ClientRepositoryImpl : IClientRepository
    {
        private readonly ClientDbContext _context;

        public ClientRepositoryImpl(ClientDbContext context)
        {
            _context = context;
        }
        public async Task<List<Client>> GetWithStoreProcedure(int page, int pageSize)
        {
            var paramPage = new SqlParameter("@Page", page);
            var paramSize = new SqlParameter("@PageSize", pageSize);
            List<ClientDto> clientsDtos = await _context.Set<ClientDto>()
                .FromSqlRaw("EXEC GetClients @Page, @PageSize", paramPage, paramSize)
                .ToListAsync();

            List<Client> clients = clientsDtos.Select(c => new Client()
            {
                Country = new Country() { Name = c.Country },
                CountryId = c.CountryId,
                Id = Guid.Parse(c.Id),
                Name = c.Name,
                Phone = c.Phone
            }
            ).ToList();

            return clients;
        }

        public async Task<List<Client>> GetWithLinq(int page, int pageSize)
        {
            return await _context.Clients
                .Include(c => c.Country)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetTotalClientsCount()
        {
            var query = _context.Clients.AsNoTracking();
            return await query.CountAsync();
        }
    }
}
