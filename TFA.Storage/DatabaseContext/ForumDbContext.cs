using Microsoft.EntityFrameworkCore;
using TFA.Storage.Configurations;
using TFA.Storage.Models;

namespace TFA.Storage.DatabaseContext
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> option) : base(option) { }

        public DbSet<Forum> Forums { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentConfiguration()); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
