using System.Linq;
using System.Threading.Tasks;
using cityGuide.Data;
using cityGuide.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (HttpContext.Session.GetString("isUserLogin")!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {   
            var login = await _context.User.Where(u => u.Mail == user.Mail && u.Password == user.Password).FirstOrDefaultAsync();
            if(login == null){
                ViewData["error"]="User not found.";
                return View();
            }
            HttpContext.Session.SetString("isUserLogin", "true"); 
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }

    }
}