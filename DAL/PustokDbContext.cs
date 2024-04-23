using Microsoft.EntityFrameworkCore;
using Pustok.Models;

namespace Pustok.DAL
{
    public class PustokDbContext:DbContext
    {
        public PustokDbContext(DbContextOptions<PustokDbContext> options):base(options)
        {
            
        }
        public DbSet<Slider> Sliders { get; set; } 
    }
}
