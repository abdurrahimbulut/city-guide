using System.Linq;
using System.Threading.Tasks;
using cityGuide.Data;
using cityGuide.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cityGuide.Controllers
{
    public class CitiesController : Controller
    {
        private readonly Context _context;
        public CitiesController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> NewComment(int id, Comment comment)
        {
            if (HttpContext.Session.GetString("isUserLogin") != null)
            {
                comment.CityId = id;
                comment.UserId = int.Parse(HttpContext.Session.GetString("UserId"));
                await _context.Comment.AddAsync(comment);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return RedirectToAction("Details", "Cities", new {id});

                }
                return RedirectToAction("Details", "Cities",new {id});

            }
            else
            {
                return RedirectToAction("Details", "Cities", new {id});
            }
        }
        public async Task<IActionResult> Index()
        {

            var city = await _context.City.ToListAsync();

            return View(city);
        }
        public async Task<IActionResult> Details(int id)
        {

            var city = await _context.City.Include(c => c.Comment).ThenInclude(y => y.User).FirstOrDefaultAsync(c => c.CityId == id);


            return View(city);
        }
    }
}