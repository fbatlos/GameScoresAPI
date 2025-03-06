using Microsoft.EntityFrameworkCore;
using GameScoreAPI.Models;

namespace GameScoreAPI.Data
{
    public class GameScoreContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }

        public GameScoreContext(DbContextOptions<GameScoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
