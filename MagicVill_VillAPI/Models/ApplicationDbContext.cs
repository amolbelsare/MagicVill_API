using Microsoft.EntityFrameworkCore;

namespace MagicVill_VillAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {               
        }
        public DbSet<Villa> Villas { get; set; }
    }
}
