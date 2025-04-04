﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFA.Storage.Models
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; } 

        public string Text { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }
        
        public DateTimeOffset? UpdatedAt { get; set; }

        public Guid TopicId { get; set; }
        [ForeignKey(nameof(TopicId))]
        public Topic Topic { get; set; }

        public Guid UserId { get; set; }

        public User Author { get; set; }

    }
}
