using Microsoft.EntityFrameworkCore;

namespace ParcelService.Database
{
    public class ParcelDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=THUNDER-PC\SQLEXPRESS;Initial Catalog=ParcelServiceDb; User ID = ParcelService; Password = parcel123; ");
        }
    }
}
