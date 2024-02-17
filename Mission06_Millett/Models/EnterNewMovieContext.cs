using Microsoft.EntityFrameworkCore;

namespace Mission06_Millett.Models
{
    public class EnterNewMovieContext : DbContext
    {
        public EnterNewMovieContext(DbContextOptions<EnterNewMovieContext> options): base (options)
        {
        }

        public DbSet<EnterNewMovie> Movies { get; set; }
    }
}
