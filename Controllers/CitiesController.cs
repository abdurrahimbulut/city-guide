using System.Linq;
using System.Threading.Tasks;
using cityGuide.Data;
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

            var city = await _context.City.FirstOrDefaultAsync();
            /*if (city == null)
            {
                return NotFound();
            }*/
            return View(city);
        }
    }
}