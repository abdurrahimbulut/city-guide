using cityGuide.Data;
using Microsoft.AspNetCore.Mvc;

namespace cityGuide.Controllers
{
    public class UserController : Controller
    {
        private readonly Context _context;
        public UserController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}