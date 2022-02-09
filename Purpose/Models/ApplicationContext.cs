using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Purpose.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Collect> collects { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<ItemLike> itemsLike { get; set; }
        public DbSet<Comment> comments { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
