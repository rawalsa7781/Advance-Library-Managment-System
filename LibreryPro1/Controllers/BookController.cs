using LibraryPro1.Data;
using LibraryPro1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryPro1.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext _context;

        public BookController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}