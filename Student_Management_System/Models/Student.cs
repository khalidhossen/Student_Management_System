using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Management_System.Models
{
	public class Student
	{
		[Key]
		public int StudentId { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date of Birth")]
		public DateTime DateOfBirth { get; set; }
		public string ImagePath { get; set; }


		public virtual ICollection<Enrollment> Enrollments { get; set; }
	}
}