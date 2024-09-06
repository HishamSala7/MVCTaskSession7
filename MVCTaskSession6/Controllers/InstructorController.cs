using Microsoft.AspNetCore.Mvc;
using MVC_Task2.Models;

namespace MVC_Task2.Controllers
{
	public class InstructorController : Controller
	{
		WebAppContext context = new WebAppContext();
		public IActionResult Index()
		{
			List<Instructor> InstructorList = context.Instructors.ToList();
			return View("Index",InstructorList);
		}

		public IActionResult Details(int id)
		{
			Instructor instructor = context.Instructors.FirstOrDefault(x=>x.Id == id);
			return View("Details", instructor);
		}

		[HttpGet]
		public IActionResult AddNewInstructor()
		{
			ViewBag.Depts = context.Departments.ToList();
			ViewBag.Courses = context.Courses.ToList();
			return View("AddNewInstructor");
		}

		[HttpPost]
		public IActionResult Save(Instructor instructor)
		{
			if(instructor.Name != null)
			{
				context.Instructors.Add(instructor);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
            ViewBag.Depts = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();
			return View("AddNewInstructor",instructor);
        }

		public IActionResult Edit(int Id)
		{
			var instructor = context.Instructors.FirstOrDefault(x => x.Id == Id);
			if(instructor != null)
			{
                ViewBag.Depts = context.Departments.ToList();
                ViewBag.Courses = context.Courses.ToList();
                return View("Edit",instructor);
            }
			return RedirectToAction("Index");
        }

		[HttpPost]
		public IActionResult SaveEdit(Instructor instructor , int Id)
		{
			var ins = context.Instructors.FirstOrDefault(x=>x.Id==Id);
			if(instructor.Name != null)
			{
				ins.Name = instructor.Name;
				ins.Salary = instructor.Salary;
				ins.Address = instructor.Address;
				ins.ImagePath = instructor.ImagePath;
				ins.DepartmentId = instructor.DepartmentId;
				ins.CourseId = instructor.CourseId;
				context.SaveChanges();
				return RedirectToAction("Index");
			}
            ViewBag.Depts = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();
            return View("Edit",instructor);
		}

		public IActionResult Delete(int Id)
		{
			Instructor instructor = context.Instructors.FirstOrDefault(x => x.Id == Id);
			if(instructor != null)
			{
				context.Instructors.Remove(instructor);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
	}
}
