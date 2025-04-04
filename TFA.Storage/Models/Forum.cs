﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFA.Storage.Models
{
    public class Forum
    {
        [Key]
        public Guid ForumId { get; set; }
        public string Title { get; set; }

        [InverseProperty(nameof(Topic.Forum))]
        public ICollection<Topic>? Topics { get; set; }
    }
}
