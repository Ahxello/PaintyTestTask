namespace PaintyTestTask.Entities
{
    public class Friend
    {
        public Guid FriendId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set;  }    
    }

}
