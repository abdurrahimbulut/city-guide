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

        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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
            var loginUser = await _context.User.Where(u => u.Mail == user.Mail && u.Password == user.Password).FirstOrDefaultAsync();
            if(loginUser == null){
                ViewData["message"]="User not found.";
                return View();
            }
            HttpContext.Session.SetString("isUserLogin", "true"); 
            HttpContext.Session.SetString("UserId", loginUser.UserId.ToString()); 
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        { 
            if (HttpContext.Session.GetString("isUserLogin")!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var usr = await _context.User.Where(u => u.Mail == user.Mail).FirstOrDefaultAsync();
            if (usr !=null)
            {
                ViewData["message"]="Mail is already in use.";
                return View();
            }
            await _context.User.AddAsync(user);
            var result = await _context.SaveChangesAsync();
            if (result >0)
            {
                HttpContext.Session.SetString("isUserLogin", "true"); 
                return RedirectToAction("Index", "Home");
            }
            ViewData["message"]="Error.";
            return View();
        }

    }
}