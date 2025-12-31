using Clients.Dtos;
using Clients.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clients.Db
{
    public class ClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ClientDto> ClientDtos { get; set; }
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Clients)
                .HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<ClientDto>().HasNoKey();


            base.OnModelCreating(modelBuilder);
        }
    }
}
