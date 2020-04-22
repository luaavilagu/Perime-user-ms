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

    }
}