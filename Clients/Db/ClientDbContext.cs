using Clients.Dtos;
using Clients.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clients.Data
{
    internal class ClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options)
        {

        }
    }
}
