using Microsoft.AspNetCore.Mvc;
using PaintyTestTask.Data;
using PaintyTestTask.Entities;
using PaintyTestTask.Interfaces;
using PaintyTestTask.Interfaces.Repositories;
using PaintyTestTask.Models;

namespace PaintyTestTask.Controllers
{
    public class FriendsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<User> _repository;
        private readonly IFriendshipService _friendshipService;
        public FriendsController(IFriendshipService friendshipService, IRepository<User> repository, ApplicationDbContext context)
        {
            _friendshipService = friendshipService;
            _repository = repository;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _context.Users.ToList();
            return View(model);
        }

    }
}
