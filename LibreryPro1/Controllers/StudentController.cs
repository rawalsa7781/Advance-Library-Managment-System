using LibraryPro1.Data;
using LibraryPro1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryPro1.Controllers
{
    public class StudentController : Controller
    {
        private readonly LibraryDbContext _context;

        public StudentController(LibraryDbContext context)
        {
            _context = context;
        }

        // Display all students
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // Open Create Page
        public IActionResult Create()
        {
            return View();
        }

        // Save Student
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(student);
        }
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}