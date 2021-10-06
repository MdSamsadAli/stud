using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using student_management_system.Models;
using System.Data.Entity;

namespace student_management_system.Controllers
{
    public class CoursesController : Controller
    {
        studentEntities db = new studentEntities();
        // GET: Courses
        public ActionResult Index()
        {
            return View(db.courses.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
        public ActionResult CreateNew()
        {
            CommonDropDown();
            return View();
        }
        private void CommonDropDown()
        {
            ViewBag.courseList = new SelectList(db.courses.ToList(), "id" );
        }
        [HttpPost]
        public ActionResult CreateNew(course Course)
        {
            db.courses.Add(Course);
            db.SaveChanges();
            ViewBag.Message = "Saved Successful";
            return View();
        }
    }
}