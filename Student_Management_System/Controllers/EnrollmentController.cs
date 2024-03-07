using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_System.Controllers
{
    public class EnrollmentController : Controller
    {
        MyDbContext _db = new MyDbContext();
        // GET: Enrollment
        public ActionResult Index()
        {
            var data = _db.Enrollments.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
			ViewBag.Student = _db.Students.ToList();
			ViewBag.Course = _db.Courses.ToList();
			return View();
        }
        [HttpPost]
		public ActionResult Create(Enrollment e)
		{
            _db.Enrollments.Add(e);
            _db.SaveChanges();
			return RedirectToAction("Index","Enrollment");
		}
		public ActionResult Edit(int id)
		{
			ViewBag.Student = _db.Students.ToList();
			ViewBag.Course = _db.Courses.ToList();
			var data = _db.Enrollments.Where(model=>model.EnrollmentId== id).FirstOrDefault();
			Session["DateOfEnrollment"] = data.EnrollmentDate;
			return View(data);
		}
		[HttpPost]
		public ActionResult Edit(Enrollment e)
		{
			var data = _db.Enrollments.Where(model=>model.EnrollmentId==e.EnrollmentId).FirstOrDefault();
			if (data != null)
			{
				data.EnrollmentId = e.EnrollmentId;
				data.StudentId = e.StudentId;
				data.CourseId = e.CourseId;
				data.EnrollmentDate = e.EnrollmentDate;
				_db.SaveChanges();
			}
			return RedirectToAction("Index","Enrollment");
		}
		public ActionResult Delete(int id)
		{
			var data = _db.Enrollments.FirstOrDefault(model => model.EnrollmentId == id);
			if (data == null)
			{
				// Handle the case where the entity with the specified ID does not exist
				return HttpNotFound(); // Or any other appropriate action
			}

			_db.Enrollments.Remove(data);
			_db.SaveChanges();

			return RedirectToAction("Index", "Enrollment");
		}
	}
}