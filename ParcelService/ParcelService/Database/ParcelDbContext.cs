using Microsoft.EntityFrameworkCore;

namespace ParcelService.Database
{
    public class ParcelDbContext : DbContext
    {
        public DbSet<Parcel> Parcels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=91.148.103.233,1433\SQLEXPRESS;Initial Catalog=ParcelServiceDb; User ID = ParcelService; Password = parcel123; ");
        }
    }
}
