using Microsoft.AspNetCore.Mvc;

namespace PaintyTestTask.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
