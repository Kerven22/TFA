namespace TFA.Domain.Models
{
    public class TopicDto
    {
        public Guid Id { get; set; }
        public Guid ForumId { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string Author { get; set; }
    }
}
