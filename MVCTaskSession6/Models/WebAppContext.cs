using Microsoft.EntityFrameworkCore;

namespace MVC_Task2.Models
{
	public class WebAppContext : DbContext
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Department>()
				.HasData(new Department { Id = 1, Name = "IT", ManagerName = "Ali" },
						 new Department { Id = 2, Name = "SWE", ManagerName = "Raouf" },
						 new Department { Id = 3, Name = "IS", ManagerName = "Hassan" },
						 new Department { Id = 4, Name = "DS", ManagerName = "Moataz" }
				);


			modelBuilder.Entity<Course>()
				.HasData(new Course { Id = 1, Name = "Database", MinDegree = 60, Degree = 100 },
						 new Course { Id = 2, Name = "Software Engineering", MinDegree = 70, Degree = 120 },
						 new Course { Id = 3, Name = "Math", MinDegree = 100, Degree = 150 },
						 new Course { Id = 4, Name = "C# Fundamentals", MinDegree = 65, Degree = 80 },
						 new Course { Id = 5, Name = "Web Fundamentals", MinDegree = 55, Degree = 100 }
				);

			
			modelBuilder.Entity<Trainee>()
				.HasData(new Trainee { Id = 1, Name = "Abdo", Address = "Giza", ImagePath = "1.jpg", Grade = 150 },
						 new Trainee { Id = 2, Name = "Omar", Address = "Cairo", ImagePath = "2.jpg", Grade = 180 },
						 new Trainee { Id = 3, Name = "Khaled", Address = "Alex", ImagePath = "3.jpg", Grade = 200 },
						 new Trainee { Id = 4, Name = "Loay", Address = "Aswan", ImagePath = "4.jpg", Grade = 120 },
						 new Trainee { Id = 5, Name = "Ibrahem", Address = "Maadi", ImagePath = "1.jpg", Grade = 115 },
						 new Trainee { Id = 6, Name = "Fawzy", Address = "Nasr City", ImagePath = "2.jpg", Grade = 190 },
						 new Trainee { Id = 7, Name = "Mohamed", Address = "Dokki", ImagePath = "3.jpg", Grade = 100 }

				);


			modelBuilder.Entity<CourseResult>()
				.HasData(new CourseResult { Id = 1, Degree = 80, TraineeId = 1, CourseId = 1 },
						 new CourseResult { Id = 2, Degree = 90, TraineeId = 1, CourseId = 3 },
						 new CourseResult { Id = 3, Degree = 75, TraineeId = 1, CourseId = 5 },
						 new CourseResult { Id = 4, Degree = 90, TraineeId = 2, CourseId = 2 },
						 new CourseResult { Id = 5, Degree = 95, TraineeId = 2, CourseId = 1 },
						 new CourseResult { Id = 6, Degree = 70, TraineeId = 2, CourseId = 4 },
						 new CourseResult { Id = 7, Degree = 90, TraineeId = 3, CourseId = 5 },
						 new CourseResult { Id = 8, Degree = 140, TraineeId = 3, CourseId = 3 },
						 new CourseResult { Id = 9, Degree = 90, TraineeId = 5, CourseId = 1 },
						 new CourseResult { Id = 10, Degree = 110, TraineeId = 5, CourseId = 3 },
						 new CourseResult { Id = 11, Degree = 60, TraineeId = 5, CourseId = 5 },
						 new CourseResult { Id = 12, Degree = 80, TraineeId = 7, CourseId = 5 },
						 new CourseResult { Id = 13, Degree = 60, TraineeId = 7, CourseId = 4 },
						 new CourseResult { Id = 14, Degree = 80, TraineeId = 7, CourseId = 1 },
						 new CourseResult { Id = 15, Degree = 80, TraineeId = 6, CourseId = 4 },
						 new CourseResult { Id = 16, Degree = 120, TraineeId = 6, CourseId = 3 }
				);

			modelBuilder.Entity<Instructor>()
		.HasData(new Instructor { Id = 1, Name = "Dr.Khaled", Salary = 5000, Address = "Moatam", ImagePath = "1.jpg", CourseId = 1, DepartmentId = 2 },
				 new Instructor { Id = 2, Name = "Dr.Mona", Salary = 15000, Address = "El-zahraa", ImagePath = "3.jpg", CourseId = 5, DepartmentId = 1 },
				 new Instructor { Id = 3, Name = "Dr.Sara", Salary = 8000, Address = "Agouza", ImagePath = "2.jpg", CourseId = 1, DepartmentId = 2 },
				 new Instructor { Id = 4, Name = "Dr.Sally", Salary = 9000, Address = "October", ImagePath = "1.jpg", CourseId = 5, DepartmentId = 3 },
				 new Instructor { Id = 5, Name = "Dr.Ismail", Salary = 10000, Address = "Alex", ImagePath = "3.jpg", CourseId = 2, DepartmentId = 4 },
				 new Instructor { Id = 6, Name = "Dr.Sami", Salary = 20000, Address = "El-Rehab", ImagePath = "4.jpg", CourseId = 3, DepartmentId = 4 },
				 new Instructor { Id = 7, Name = "Dr.Samir", Salary = 12000, Address = "Aswan", ImagePath = "2.jpg", CourseId = 4, DepartmentId = 1 },
				 new Instructor { Id = 8, Name = "Dr.Mahmoud", Salary = 11000, Address = "Nasr City", ImagePath = "4.jpg", CourseId = 5, DepartmentId = 3 }
			);

			base.OnModelCreating(modelBuilder);
		}



		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseResult> CourseResults { get; set; }
		public DbSet<Trainee> Trainees { get; set; }
		public DbSet<Instructor> Instructors  { get; set; }
		public DbSet<Department> Departments { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=.;Database=MVCTaks2;Trusted_Connection=true;TrustServerCertificate=true");
			base.OnConfiguring(optionsBuilder);
		}

	}
}
