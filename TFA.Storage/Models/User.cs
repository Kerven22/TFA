using System.ComponentModel.DataAnnotations.Schema;

namespace TFA.Storage.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }

        [InverseProperty(nameof(Topic.Author))]
        public ICollection<Topic> Topics { get; set; }

        [InverseProperty(nameof(Comment.Author))]
        public ICollection<Comment> Comments { get; set; }
    }
}
