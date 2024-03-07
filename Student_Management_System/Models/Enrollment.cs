using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Management_System.Models
{
	public class Enrollment
	{
		[Key]
		public int EnrollmentId { get; set; }

		[ForeignKey("Student")]
		public int StudentId { get; set; }
		public virtual Student Student { get; set; }

		[ForeignKey("Course")]
		public int CourseId { get; set; }
		public virtual Course Course { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Enrollment Date")]
		public DateTime EnrollmentDate { get; set; }
	}
}