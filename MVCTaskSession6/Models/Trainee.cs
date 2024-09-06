namespace MVC_Task2.Models
{
	public class Trainee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public float Grade { get; set; }
		public string Address { get; set; }
		public string ImagePath { get; set; }
		public virtual ICollection<CourseResult> CourseResult { get; set; }
	}
}
