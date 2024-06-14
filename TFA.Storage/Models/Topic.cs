using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFA.Storage.Models
{
    public class Topic
    {
        [Key]
        public Guid TopicId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string Title { get; set; }


        public Guid FormId { get; set;  }
        [ForeignKey(nameof(FormId))]
        public Form Form { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User Author { get; set; }

        [InverseProperty(nameof(Comment.Topic))]
        public ICollection<Comment?>? Comments { get; set; }
    }
}
