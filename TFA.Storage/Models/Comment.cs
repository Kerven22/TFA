﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFA.Storage.Models
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string Title { get; set; }


        public Guid UserId { get; set;  }
        [ForeignKey(nameof(UserId))]
        public User Author { get; set; }

        public Guid TopicId { get; set; }
        [ForeignKey(nameof(TopicId))]
        public Topic Topic { get; set; }
    }
}
