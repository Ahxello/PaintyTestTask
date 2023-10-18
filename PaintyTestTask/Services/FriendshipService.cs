using Microsoft.EntityFrameworkCore;
using PaintyTestTask.Data;
using PaintyTestTask.Entities;
using PaintyTestTask.Interfaces;
using PaintyTestTask.Interfaces.Repositories;

namespace PaintyTestTask.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IRepository<User> _db;
        private readonly ApplicationDbContext _context;
        public FriendshipService(IRepository<User> db, ApplicationDbContext context)
        {
            _db = db;
            _context = context;
        }


        public async Task<bool> AddFriend(Guid userId, Guid friendId)
        {
            try
            {
                var user = _db.GetById(userId);
                var friend = _db.GetById(friendId);
                if (user == null || friend == null)
                {
                    return false; // Пользователь или друг не найден
                }
                if (_context.Friendship.Any(f => (f.UserId == userId && f.FriendId == friendId) || (f.UserId == friendId && f.FriendId == userId)))
                {
                    return false; // Уже друзья
                }
                var friendship = new Friendship
                {
                    UserId = userId,
                    FriendId = friendId,
                    Status = FriendshipStatus.Pending
                };
                await _context.Friendship.AddAsync(friendship);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public async Task<bool> AcceptFriendRequest(Guid friendshipId)
        {
            try
            {
                Friendship friendship = _context.Friendship.Find(friendshipId);

                if (friendship == null || friendship.Status != FriendshipStatus.Pending)
                {
                    return false; // Некорректная заявка
                }

                friendship.Status = FriendshipStatus.Accepted;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, логирование и т.д.
                return false;
            }
        }
        public async Task<bool> RejectFriendRequest(Guid friendshipId)
        {
            try
            {
                var friendship = _context.Friendship.Find(friendshipId);

                if (friendship == null || friendship.Status != FriendshipStatus.Pending)
                {
                    return false; // Некорректная заявка
                }

                friendship.Status = FriendshipStatus.Rejected;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, логирование и т.д.
                return false;
            }
        }
        public async Task<User> SearchUsers(string username)
        {
            User user = await _db.GetByName(username);
            return user;
        }
    }
}
