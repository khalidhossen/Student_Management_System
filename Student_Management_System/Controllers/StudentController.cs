using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Student_Management_System.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        MyDbContext _db = new MyDbContext();
        public ActionResult Index()
        {
            var data = _db.Students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Create(Student student, HttpPostedFileBase imageFile)
		{
			if (ModelState.IsValid)
			{
				try
				{
					if (imageFile != null && imageFile.ContentLength > 0 && imageFile.ContentLength<=1000000)
					{
						
						var fileName = Path.GetFileName(imageFile.FileName);
						var imagePath = Path.Combine(Server.MapPath("~/Images"), fileName);
						imageFile.SaveAs(imagePath);
						student.ImagePath = "~/Images/" + fileName; // Save relative path to database
					}

					// Save student to the database
					// Assuming db is your DbContext instance
					_db.Students.Add(student);
					_db.SaveChanges();

					return RedirectToAction("Index", "Student");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", "Error occurred while saving the student: " + ex.Message);
				}
			}

			// If ModelState is not valid or an error occurred, return to the Create view with the student model
			return View(student);
		}

		public ActionResult Edit(int id)
		{
			var data = _db.Students.Where(model => model.StudentId == id).FirstOrDefault();
			Session["image"] = data.ImagePath;
			Session["DateOfBirth"] = data.DateOfBirth;
			return View(data);
		}
		[HttpPost]
		public ActionResult Edit(Student student, HttpPostedFileBase imageFile)
		{
			var data = _db.Students.FirstOrDefault(model => model.StudentId == student.StudentId);
			if (data != null)
			{
				try
				{
					data.Name = student.Name;
					data.Email = student.Email;
					data.DateOfBirth = student.DateOfBirth;

					if (imageFile != null && imageFile.ContentLength > 0)
					{
						var fileName = Path.GetFileName(imageFile.FileName);
						var imagePath = Path.Combine(Server.MapPath("~/Images"), fileName);
						imageFile.SaveAs(imagePath);
						data.ImagePath = "~/Images/" + fileName; // Save relative path to database
					}

					_db.SaveChanges();
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", "An error occurred while saving the student data: " + ex.Message);
				}
			}
			return RedirectToAction("Index", "Student");
		}
		public ActionResult Delete(int id)
		{
			var data = _db.Students.Where(model => model.StudentId == id).FirstOrDefault();
			_db.Students.Remove(data);
			_db.SaveChanges();
			return RedirectToAction("Index","Student");
		}
	}
}