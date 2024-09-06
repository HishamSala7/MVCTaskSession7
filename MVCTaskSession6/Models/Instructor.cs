namespace MVC_Task2.Models
{
	public class Instructor
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public float Salary { get; set; }
		public string Address { get; set; }
		public string ImagePath { get; set; }
		public int DepartmentId { get; set; }
		public int CourseId { get; set; }
		public virtual Department Department { get; set; }
		public virtual Course Course { get; set; }
	}
}
