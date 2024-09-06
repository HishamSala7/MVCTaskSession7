using MVC_Task2.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCTaskSession6.Models
{
    public class   UniqueNameAttribute  : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Error!! You Must Enter Course Name First");
            }
            WebAppContext context = new WebAppContext();
            string CrsName = value.ToString();
            Course course = context.Courses.FirstOrDefault(x => x.Name == CrsName);

            if (course == null)
               return ValidationResult.Success;

            return new ValidationResult("Error!! Course Name is already exists");

            //return base.IsValid(value, validationContext);
        }
    }
}
