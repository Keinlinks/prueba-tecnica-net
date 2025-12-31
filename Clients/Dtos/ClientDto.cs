
namespace Clients.Dtos
{
    public record ClientDto
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Phone { get; init; }
        public string Country { get; init; }
        public int CountryId { get; init; }

        public ClientDto() { }

    }
}
