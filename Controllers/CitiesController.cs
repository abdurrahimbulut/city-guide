using System.Linq;
using System.Threading.Tasks;
using cityGuide.Data;
using cityGuide.Models;
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
        public async Task<IActionResult> Index()
        {

            var city = await _context.City.ToListAsync();

            return View(city);
        }
        public async Task<IActionResult> Details(int id)
        {

            var city = await _context.City.Include(c => c.Comment).ThenInclude(y => y.User).FirstOrDefaultAsync(c =>c.CityId ==id );


            return View(city);
        }
    }
}