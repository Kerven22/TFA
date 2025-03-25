using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFA.Storage.Models;

namespace TFA.Storage.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(c => c.Author)
                .WithMany(d => d.Comments)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction); 
        }
    }
}
