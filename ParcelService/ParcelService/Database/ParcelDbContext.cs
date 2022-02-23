using Microsoft.EntityFrameworkCore;

namespace ParcelService.Database
{
    public class ParcelDbContext : DbContext
    {
        public DbSet<DeoParcele>? DeoParcele { get; set; }
        public DbSet<Parcel>? Parcels { get; set; }
        public DbSet<KatastarskaOpstina>? KatastarskaOpstina { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=host.docker.internal,1433\SQLEXPRESS;Initial Catalog=ParcelServiceDb; User ID = ParcelService; Password = parcel123; ");
        }
    }
}
