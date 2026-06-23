using LibraryPro1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DashboardController : Controller
{
    private readonly LibraryDbContext _context;

    public DashboardController(LibraryDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.TotalBooks = _context.Books.Count();

        ViewBag.TotalStudents = _context.Students.Count();

        ViewBag.IssuedBooks = _context.IssueBooks
            .Count(x => x.IsReturned == false);

        var returnedBooks = _context.IssueBooks.ToList();

        ViewBag.ReturnedBooks = returnedBooks.Count(x => x.IsReturned);

        var activities = _context.IssueBooks
     .Include(x => x.Student)
     .Include(x => x.Book)
     .OrderByDescending(x => x.IssueDate)
     .Take(10)
     .ToList();
        return View(activities);
    }
}