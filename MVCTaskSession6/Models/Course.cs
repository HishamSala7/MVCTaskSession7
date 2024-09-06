using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using MVCTaskSession6.Models;


namespace MVC_Task2.Models
{
	public class Course
	{
		public int Id { get; set; }
		//[Required /*(ErrorMessage = "You must enter Course name")*/]
		[UniqueName]
		public string Name { get; set; }
		[Required]
		public float Degree { get; set; }
		[Required]
		public float MinDegree { get; set; }
		public virtual ICollection <CourseResult>? CourseResults  { get; set; }
		public virtual ICollection<Instructor>? Instructors { get; set; }
	}
}
