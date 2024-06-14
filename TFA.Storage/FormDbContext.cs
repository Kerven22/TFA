using Microsoft.EntityFrameworkCore;
using TFA.Storage.Configurations;
using TFA.Storage.Models;

namespace TFA.Storage
{
    public class FormDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Topic> Topics { get; set; }

        public FormDbContext(DbContextOptions<FormDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
