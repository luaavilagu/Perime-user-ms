using Microsoft.EntityFrameworkCore;
using userService.Model;

namespace userService.DBContext
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<User> Users {get; set;}

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    id = 1,
                    username = "Username1",
                    passhash = "Passhash1",
                    address = "Address1",
                    cellphone = 0000000001,
                    email = "Email1"
                },
                 new User
                {
                    id = 2,
                    username = "Username2",
                    passhash = "Passhash2",
                    address = "Address2",
                    cellphone = 0000000002,
                    email = "Email1"
                }   
            );
        }
        */
        

    }
}