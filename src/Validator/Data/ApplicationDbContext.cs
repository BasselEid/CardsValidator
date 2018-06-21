using Microsoft.EntityFrameworkCore;

namespace Validator.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}