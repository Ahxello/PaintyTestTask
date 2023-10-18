using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaintyTestTask.Data;
using PaintyTestTask.Entities;
using PaintyTestTask.Interfaces.Repositories;

namespace PaintyTestTask.Controllers
{
    public class PicturesController : Controller
    {
        private readonly IRepository<Picture> _repositoryPicture;
        private readonly IRepository<User> _repositoryUser;
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _context;
        public PicturesController(IWebHostEnvironment environment, ApplicationDbContext context, IRepository<Picture> repositoryPicture, IRepository<User> repositoryUser)
        {
            _environment = environment;
            _context = context;
            _repositoryPicture = repositoryPicture;
            _repositoryUser = repositoryUser;
        }
        public IActionResult Index(Guid userId)
        {
            ViewBag.UserId = userId;
            return View("Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> ProcessUploadImage(Guid userId)
        //{
            
        //}
    }
}
