using LibraryPro1.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibreryPro1.Controllers
{
    public class ReportController : Controller
    {
        private readonly LibraryDbContext _context;

        public ReportController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalBooks = _context.Books.Count();
            ViewBag.TotalStudents = _context.Students.Count();
            ViewBag.TotalIssuedBooks = _context.IssueBooks.Count();
            ViewBag.TotalReturnedBooks =
                _context.IssueBooks.Count(x => x.IsReturned);

            ViewBag.TotalRacks = _context.Racks.Count();

            return View();
        }
    }
}