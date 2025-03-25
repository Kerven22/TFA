using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFA.Storage.Models;

namespace TFA.Storage.DatabaseContext
{
    public class ForumDbContext:DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext>option):base(option)
        {
            
        }
        

        public DbSet<Forum> Forums { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
