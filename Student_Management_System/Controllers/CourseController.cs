using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_System.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        MyDbContext _db = new MyDbContext();
        public ActionResult Index()
        {
            var data = _db.Courses.ToList();
            return View(data);
        } 
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public ActionResult Create(Course c)
		{
            _db.Courses.Add(c);
            _db.SaveChanges();
			return RedirectToAction("Index","Course");
		} 
        public ActionResult Edit(int id)
        {
            var data = _db.Courses.Where(model => model.CourseId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
		public ActionResult Edit(Course c)
		{
			var data = _db.Courses.Where(model => model.CourseId == c.CourseId).FirstOrDefault();
            if (data != null)
            {
                data.CourseId = c.CourseId;
                data.CourseTitle = c.CourseTitle;
                data.Description = c.Description;
                _db.SaveChanges();
            }
			return RedirectToAction("Index","Course");
		}
        public ActionResult Delete(int id)
        {
            var data = _db.Courses.Where(model => model.CourseId == id).FirstOrDefault();
            _db.Courses.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("Index","Course");
        }
	}
}