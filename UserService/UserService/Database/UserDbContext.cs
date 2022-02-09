using Microsoft.EntityFrameworkCore;

namespace UserService.Database
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Data Source=195.252.66.53,1433\SQLEXPRESS;Initial Catalog=UserServiceDb; User ID = UserService; Password = user123; ");
        }
    }
}
