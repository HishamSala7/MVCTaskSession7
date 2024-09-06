using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Task2.Models
{
	public class CourseResult
	{
		public int Id { get; set; }
		public float Degree { get; set; }
		public int TraineeId { get; set; }
		public int CourseId { get; set; }
		public virtual Trainee? Trainee { get; set; }
		public virtual Course? Course { get; set; }

	}
}
