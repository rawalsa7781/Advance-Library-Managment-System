using LibraryPro1.Data;
using LibreryPro1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibreryPro1.Controllers
{
    public class RackController : Controller
    {
        private readonly LibraryDbContext _context;

        public RackController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Racks.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Rack rack)
        {
            if (ModelState.IsValid)
            {
                _context.Racks.Add(rack);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(rack);
        }
    }
}