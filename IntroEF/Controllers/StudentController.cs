
using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class StudentController : Controller
    {
        Student_CEntities1 db = new Student_CEntities1();
        // GET: Student
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student1 s)
        {
            //validation

            db.Student1.Add(s);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            var data = db.Student1.ToList();

            return View(data);
        }
        public ActionResult Details(int id)
        {
            var data = db.Student1.Find(id);
            if (data == null)
            {
                TempData["Msg"] = "Id with value " + id + " not found";
                return RedirectToAction("List");
            }
            return View(data);
        }
    }
}