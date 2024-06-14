using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFA.Storage.Models
{
    public class Form
    {
        [Key]
        public Guid FormId { get; set; }
        public string Title { get; set; }

        [InverseProperty(nameof(Topic.Form))]
        public ICollection<Topic> Topics { get; set; }
    }
}
