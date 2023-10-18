namespace PaintyTestTask.Entities
{
    public class Friendship
    {
        public Guid FriendshipId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set;  }
        public User Friend { get; set; }
        public Guid FriendId { get; set; }
        public FriendshipStatus Status { get; set; }

    }
    public enum FriendshipStatus
    {
        Pending,
        Accepted,
        Rejected
    }

}
