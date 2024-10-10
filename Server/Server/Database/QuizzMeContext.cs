using Microsoft.EntityFrameworkCore;
using Server.Database.Entities;

namespace Server.Database
{
    public class QuizzMeContext : DbContext
    {
        public QuizzMeContext(DbContextOptions<QuizzMeContext> options) : base(options) { }

        public DbSet<QuizzEntity> Quizzes { get; set; }
        public DbSet<QuizzQuestionEntiity> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<QuizzEntity>()
                .HasKey(x => x.QuizzId);

            builder.Entity<QuizzEntity>()
                .HasMany(x => x.Questions)
                .WithOne(x => x.Quizz)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(builder);
        }
    }
}
