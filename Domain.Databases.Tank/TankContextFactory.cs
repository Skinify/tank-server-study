using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Tank
{
    public class TankContextFactory : IDesignTimeDbContextFactory<TankContext>
    {
        public TankContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TankContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=Tank;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new TankContext(optionsBuilder.Options);
        }
    }
}
