using LibraryPro1.Data;
using LibreryPro1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibreryPro1.Controllers
{
    public class IssueBookController : Controller
    {
        private readonly LibraryDbContext _context;

        public IssueBookController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.IssueBooks.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Books = _context.Books.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(IssueBook issueBook)
        {
            issueBook.IssueDate = DateTime.Now;
            issueBook.IsReturned = false;

            _context.IssueBooks.Add(issueBook);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult ReturnBook(int id)
        {
            var issueBook = _context.IssueBooks.Find(id);

            if (issueBook != null)
            {
                issueBook.IsReturned = true;
                issueBook.ReturnDate = DateTime.Now;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}