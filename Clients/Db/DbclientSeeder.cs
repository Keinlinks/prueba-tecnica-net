namespace Clients.Db
{
    public static class DbclientSeeder
    {
        public static void Seed(ClientDbContext _context)
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.AddRange(
                    new Entities.Country { Name = "Chile"},
                    new Entities.Country { Name = "Argentina"},
                    new Entities.Country { Name = "Colombia"},
                    new Entities.Country { Name = "Venezuela"},
                    new Entities.Country { Name = "Costa rica"},
                    new Entities.Country { Name = "China"},
                    new Entities.Country { Name = "Bolivia"},
                    new Entities.Country { Name = "Brasil"}
                );
                _context.SaveChanges();
            }

            if (!_context.Clients.Any())
            {
                _context.Clients.AddRange(
                    new Entities.Client { Name = "Juan", CountryId = 1, Id = Guid.NewGuid(), Phone = "+56934567892" },
                    new Entities.Client { Name = "Maria", CountryId = 1, Id = Guid.NewGuid(), Phone = "+56984738276" },
                    new Entities.Client { Name = "Pedro", CountryId = 6, Id = Guid.NewGuid(), Phone = "+56911223344" },
                    new Entities.Client { Name = "Ana", CountryId = 2, Id = Guid.NewGuid(), Phone = "+56922334455" },
                    new Entities.Client { Name = "Luis", CountryId = 1, Id = Guid.NewGuid(), Phone = "+56933445566" },
                    new Entities.Client { Name = "Carla", CountryId = 7, Id = Guid.NewGuid(), Phone = "+56944556677" },
                    new Entities.Client { Name = "Diego", CountryId = 5, Id = Guid.NewGuid(), Phone = "+56955667788" },
                    new Entities.Client { Name = "Sofia", CountryId = 4, Id = Guid.NewGuid(), Phone = "+56966778899" },
                    new Entities.Client { Name = "Martin", CountryId = 3, Id = Guid.NewGuid(), Phone = "+56977889900" },
                    new Entities.Client { Name = "Lucia", CountryId = 1, Id = Guid.NewGuid(), Phone = "+56988990011" },
                    new Entities.Client { Name = "Jorge", CountryId = 2, Id = Guid.NewGuid(), Phone = "+56999001122" },
                    new Entities.Client { Name = "Valentina", CountryId = 1, Id = Guid.NewGuid(), Phone = "+56910111213" },
                    new Entities.Client { Name = "Andres", CountryId = 4, Id = Guid.NewGuid(), Phone = "+56912131415" },
                    new Entities.Client { Name = "Camila", CountryId = 2, Id = Guid.NewGuid(), Phone = "+56914151617" },
                    new Entities.Client { Name = "Fernando", CountryId = 1, Id = Guid.NewGuid(), Phone = "+56916171819" },
                    new Entities.Client { Name = "Isabel", CountryId = 8, Id = Guid.NewGuid(), Phone = "+56918192021" },
                    new Entities.Client { Name = "Pablo", CountryId = 2, Id = Guid.NewGuid(), Phone = "+56920212223" },
                    new Entities.Client { Name = "Mónica", CountryId = 7, Id = Guid.NewGuid(), Phone = "+56922232425" },
                    new Entities.Client { Name = "Ricardo", CountryId = 3, Id = Guid.NewGuid(), Phone = "+56924252627" },
                    new Entities.Client { Name = "Natalia", CountryId = 2, Id = Guid.NewGuid(), Phone = "+56926272829" }
                );
                _context.SaveChanges();
            }
            
        }
    }
}
