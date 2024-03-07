using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Management_System.Models
{
	public class Course
	{
		[Key]
		public int CourseId { get; set; }

		[Required]
		[StringLength(100)]
		public string CourseTitle { get; set; }

		[StringLength(250)]
		public string Description { get; set; }
		public virtual ICollection<Enrollment> Enrollments { get; set; }
	}
}