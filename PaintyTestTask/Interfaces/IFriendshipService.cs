using PaintyTestTask.Entities;

namespace PaintyTestTask.Interfaces
{
    public interface IFriendshipService
    {
        public Task<bool> AddFriend(Guid userId, Guid friendId);
        public Task<bool> AcceptFriendRequest(Guid friendshipId);
        public Task<bool> RejectFriendRequest(Guid friendshipId);
        public Task<User> SearchUsers(string username);
    }
}
