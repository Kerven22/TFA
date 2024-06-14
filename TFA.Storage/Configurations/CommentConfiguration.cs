using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFA.Storage.Models;

namespace TFA.Storage.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasOne(f => f.Author)
                .WithMany(f => f.Comments)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder
                .HasOne(f => f.Topic)
                .WithMany(f => f.Comments)
                .HasForeignKey(f => f.TopicId)
                .OnDelete(DeleteBehavior.ClientNoAction);
                
        }
    }
}
