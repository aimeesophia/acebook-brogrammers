using Microsoft.EntityFrameworkCore;
namespace Acebook.Models
{
    public class AcebookContext : DbContext
    {
        public AcebookContext(DbContextOptions<AcebookContext> options) : base(options)
        {
        }
        public DbSet<Post> posts { get; set; }
        public DbSet<User> users { get; set; }
    }
}
