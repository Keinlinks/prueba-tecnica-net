namespace Clients.Entities
{
    internal class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Country Country { get; set; }

    }
}
