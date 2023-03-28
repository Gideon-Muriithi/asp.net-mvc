using ASP_NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC.Controllers
{
    public class StudentController : Controller
    {
        IList<Student> studentList = new List<Student> ()
        {
            new Student {StudentID = 1,StudentName = "Brian",StudentAge = 18 },
            new Student {StudentID = 2,StudentName = "Tom",StudentAge = 20 },
            new Student {StudentID = 3,StudentName = "Ken",StudentAge = 19 }
        };
        // GET: Student
        public ActionResult Index()
        {
            return View(studentList.OrderBy(s => s.StudentID).ToList());
        }

        //Action Selectors
        [NonAction]
        public string ReturnStr()
        {
            return "How are you doing today sir?";
        }

        [HttpPost]
        public ActionResult PostAction()
        {
            return View("Index");
        }

        public ActionResult Edit(int Id)
        {
            var std = studentList.Where(s => s.StudentID == Id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Student std)
        {
            if(ModelState.IsValid)
            {
                //update student in DB using EntityFramework in real-life application

                //update list by removing old student and adding updated student for demo purpose
                var student = studentList.Where(s => s.StudentID == std.StudentID).FirstOrDefault();
                //studentList.Remove(student);
                bool studentExists = studentList.Where(s => s.StudentID == std.StudentID).FirstOrDefault() != null;

               
                if(studentExists)
                {
                    ModelState.AddModelError("StudentName", "Student Already Exists.");
                    return View(std);
                }

                studentList.Add(std);


                return RedirectToAction("Index");
            }

            return View(std);
            
        }
    }
}