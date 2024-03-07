using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_System.Controllers
{
	public class HomeController : Controller
	{
		MyDbContext _db = new MyDbContext();
		public ActionResult Index()
		{
			var data = _db.Enrollments.ToList();
			return View(data);
		}
		public ActionResult Details(int id)
		{
			var data = _db.Enrollments.Where(model => model.EnrollmentId == id).FirstOrDefault();
			
			return View(data);
		}

	}
}