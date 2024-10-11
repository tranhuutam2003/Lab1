using Lab1.Data;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolContext db;

        public CourseController(SchoolContext context)
        {
            db = context;
        }

        [Route("Course/List")]
        public IActionResult Index()
        {
            var courses = db.Courses.ToList(); 
            return View(courses);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            try
            {   //kiểm tra mã theo sp
                bool exist = db.Courses.Any(x => x.CourseId == course.CourseId);
                if (exist)
                {//Thông báo lỗi khi mã sản phẩm đã tồn tại
                    ModelState.AddModelError("Course ID", "Mã sản phẩm này đã tồn tại.");
                    return View(course);
                }


                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");


            }
            catch (Exception ex)
            {
                //ViewBag.Message = "Lỗi liên hệ với admin";
                return View();
            }

        }

        public IActionResult Edit(int id)
        {
            if (db.Courses == null)
            {
                return NotFound();
            }

            var learner = db.Courses.Find(id);
            if (learner == null)
            {
                return NotFound();
            }
            // ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CourseId,Title,Credits")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(course);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!CourseExists(course.CourseId))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            //    ViewBag.MajorId = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(course);
        }


        public IActionResult Delete(int id)
        {
            if (id == null || db.Courses == null)
            {
                return NotFound();
            }
            var course = db.Courses.FirstOrDefault(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            if (course.Enrollments.Count() > 0)
            {
                return Content("This learner has some enrollments, can't delete");
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            if (db.Courses == null)
            {
                return Problem("Entity set 'Learners' is null");
            }
            var course = db.Courses.Find(id);
            if (course != null)
            {
                db.Courses.Remove(course);
            }
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
