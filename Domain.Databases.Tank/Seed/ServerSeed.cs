using Microsoft.EntityFrameworkCore;
using Tank.Models.Entities.Server;

namespace Tank.Seed
{
    public static partial class Seed
    {
        public static void SeedServerConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServerConfigs>().HasData(
                new ServerConfigs { Id = 0, Name = "PublicRSAKey", Value = "-----BEGIN PUBLIC KEY-----\r\nMFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBAL1ezivGNWo8deIaiWOtukZ5hsczjqza\r\nuNeF0ieYdWN8fE6/YZpB4ZOyZiGhp8EfRlFpUjzPtw1i5CcA7K+SWHUCAwEAAQ==\r\n-----END PUBLIC KEY-----" },
                new ServerConfigs { Id = 1, Name = "PrivateRSAKey", Value = "-----BEGIN RSA PRIVATE KEY-----\r\nMIIBOgIBAAJBAL1ezivGNWo8deIaiWOtukZ5hsczjqzauNeF0ieYdWN8fE6/YZpB\r\n4ZOyZiGhp8EfRlFpUjzPtw1i5CcA7K+SWHUCAwEAAQJAMLJxiDY3RDN6CQPT8ssZ\r\nDMhxjUZH2VGBmQKzsTT2cvd94bH7V4ETGv011Tv5d31eeMudGLkiwUMIQUVBq/ba\r\nPQIhAOLCUPZxw4v/e3GnRi8Zm31wymdGk40AFuPApAGNFbDnAiEA1co6HkX4psjf\r\ny+XzxcSPlojhiyb98CQV2x5akJz1FEMCIQCLQHVjwl0pvgzasLSi/ADGudsyLN8z\r\nuZhU6NpOsYtehQIgMFrAEG7VEawnai/FljqiG3M0SEv2baVLyDayVzkY+Y8CIBji\r\ngNSm2/bwJM4fYfSsHD2BXOTneOWWP9ZtM6i30gWC\r\n-----END RSA PRIVATE KEY-----" }
            );
        }

        public static void SeedServers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servers>().HasData(
                new Servers { Id = 0, Ip = "127.0.0.1", Port = 9202, Name = "Test server" }
            );
        }
    }
}
