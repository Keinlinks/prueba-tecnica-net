namespace Clients.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
