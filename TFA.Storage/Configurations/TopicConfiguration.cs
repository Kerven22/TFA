using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFA.Storage.Models;

namespace TFA.Storage.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder
                .HasOne(f => f.Form)
                .WithMany(f => f.Topics)
                .HasForeignKey(f => f.FormId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder
                .HasOne(f => f.Author)
                .WithMany(f => f.Topics)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
