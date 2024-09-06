using Microsoft.AspNetCore.Mvc;
using MVC_Task2.Models;

namespace MVCTaskSession6.Controllers
{
    public class CourseController : Controller
    {
        WebAppContext context = new WebAppContext();
        public IActionResult Index()
        {
            var courses = context.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult AddNewCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewCourse(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, "Error occurs");

            }
            return View("AddNewCourse", course);
        }

        public IActionResult Edit(int Id)
        {
            var course = context.Courses.FirstOrDefault(x => x.Id == Id);
            if (course != null)
            { 
                return View("Edit", course);
            }
            return RedirectToAction("Index");
        }

        public IActionResult SaveEdit(Course course, int Id)
        {
            //if (course.Name != null)
            //{
                var crs = context.Courses.FirstOrDefault(x => x.Id == Id);
                if (ModelState.IsValid)
                {
                    crs.Name = course.Name;
                    crs.Degree = course.Degree;
                    crs.MinDegree = course.MinDegree;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            //}
            return View("Edit", course);
        }

        public IActionResult Delete(int Id)
        {
            var course = context.Courses.FirstOrDefault(x => x.Id == Id);
            return View(course);
        }

        public IActionResult SaveDelete(int Id)
        {
            var course = context.Courses.FirstOrDefault(x => x.Id == Id);
            context.Courses.Remove(course);
            context.SaveChanges();
            return View();
        }


    }
}
