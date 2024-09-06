using Microsoft.AspNetCore.Mvc;
using MVC_Task2.Models;

namespace MVCTaskSession6.Controllers
{
    public class CourseResultController : Controller
    {
        WebAppContext context = new WebAppContext();
        public IActionResult Index(int Id)
        {
            var Results = context.CourseResults.ToList();
            return View(Results);
        }

        public IActionResult AddNewGrade()
        {
            ViewBag.Courses = context.Courses.ToList();
            ViewBag.Trainees = context.Trainees.ToList(); 
            return View();
        }

        public IActionResult SaveNewResult(CourseResult courseResult)
        {
            if (ModelState.IsValid)
            {
                context.CourseResults.Add(courseResult);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Courses = context.Courses.ToList();
            ViewBag.Trainees = context.Trainees.ToList();
            return View("AddNewGrade", courseResult);
        }

        public IActionResult Delete(int Id)
        {
            CourseResult courseResult = context.CourseResults.FirstOrDefault(x => x.Id == Id);
            return View(courseResult);
        }

        public IActionResult SaveDelete(int Id)
        {
            var courseResult = context.CourseResults.FirstOrDefault(x => x.Id == Id);
            context.CourseResults.Remove(courseResult);
            context.SaveChanges();
            return View();
        }
        //public IActionResult Update(int Id)
        //{
        //    CourseResult courseResult = context.CourseResults.FirstOrDefault(x => x.Id == Id);
        //    return View(courseResult);
        //}

    }
}
