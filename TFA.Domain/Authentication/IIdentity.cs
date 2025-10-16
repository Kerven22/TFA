namespace TFA.Domain.Authorization
{
    public interface IIdentity
    {
        Guid UserId { get; }
    }
    public class User : IIdentity
    {
        public User(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; }
    }

    public static class IdenetityExtention
    {
        public static bool IsAuthenticate(this IIdentity identity)=>identity.UserId!=Guid.Empty;
    }
}
