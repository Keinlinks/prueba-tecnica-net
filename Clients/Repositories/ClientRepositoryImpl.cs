
using Clients.Data;
using Clients.Dtos;
using Clients.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Clients.Repositories
{
    internal class ClientRepositoryImpl : IClientRepository
    {
        private readonly ClientDbContext _context;
        public async Task<List<Client>> GetWithEF(int page, int pageSize)
        {
            var paramPage = new SqlParameter("@Page", page);
            var paramSize = new SqlParameter("@PageSize", pageSize);

            return await _context.Clients
                .FromSqlRaw("EXEC GetClients @Page, @PageSize", paramPage, paramSize)
                .ToListAsync();
        }

        public async Task<List<Client>> GetWithLinq(int page, int pageSize)
        {
            return await _context.Clients
                .Include(c => c.Country)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        }
    }
}
