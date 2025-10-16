using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFA.Storage.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }        
       
        public required string FirstName { get; set; }

        public required string SecondName { get; set; }

        
        public required string Login { get; set; }
        
        
        public required string Email { get; set; }

        [MaxLength(32)]
        public required byte[] Password { get; set; }

        
        public required string PhoneNumber { get; set; }

        [MaxLength(100)]
        public required byte[] PasswordSalt { get; set; }

        public required int Age { get; set; }

        [InverseProperty(nameof(Topic.Author))]
        public ICollection<Topic>? Topics { get; set; }

        [InverseProperty(nameof(Comment.Author))]
        public ICollection<Comment>? Comments { get; set; }
    }
}
