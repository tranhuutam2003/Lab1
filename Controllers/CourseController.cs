using Lab1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Lab1.Controllers
{
    public class CourseController : Controller
    {
        private SchoolContext db;

        public CourseController(SchoolContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var courses = db.Courses.Include(m => m.Enrollments).ToList();
            return View(courses);
        }

        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }
    }
}
