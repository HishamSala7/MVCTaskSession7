using Microsoft.AspNetCore.Mvc;
using MVC_Task2.Models;

namespace MVCTaskSession6.Controllers
{
    public class DepartmentController : Controller
    {
        WebAppContext context = new WebAppContext();
        public IActionResult Index()
        {
            List<Department> list = context.Departments.ToList();  
            return View(list);
        }

        public IActionResult AddNewDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewDepartment(Department department)
        {
            if(department.Name !=  null)
            {
                context.Departments.Add(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddNewDepartment", department);
        }

        public IActionResult Details(int Id)
        {
            Department dept = context.Departments.FirstOrDefault(x => x.Id == Id);
            return View(dept);
        }

		public IActionResult Edit(int Id)
		{
			var dept = context.Departments.FirstOrDefault(x => x.Id == Id);
			if (dept != null)
				return View("Edit", dept);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult SaveEdit(Department department, int Id)
		{
			var dept = context.Departments.FirstOrDefault(x => x.Id == Id);
			if (department.Name != null)
			{
				dept.Name = department.Name;
				dept.ManagerName = department.ManagerName;
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.Depts = context.Departments.ToList();
			ViewBag.Courses = context.Courses.ToList();
			return View("Edit", department);
		}

		public IActionResult Delete(int Id)
		{
			Department dept = context.Departments.FirstOrDefault(x => x.Id == Id);
			if (dept != null)
			{
				context.Departments.Remove(dept);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}


	}
}
