using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.DB.DBoperation;
using ERP.models;

namespace CollegeCRUD.Controllers
{
    public class HomeController : Controller
    {
        StudentRepository repository = null;
        public HomeController()
        {
            repository = new StudentRepository();
        }
        // GET: Home

        public ActionResult __Create()
        {
            var model = new Student();
            model.Genders = repository.GetGenders();

            //ViewBag.Status = model.Statuss;
            //model.Fname = "Abhishek";
            //ViewBag.gender = model.Genders;
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult __Create(Student model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddStudent(model);
                if (id>0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Data Added";

                }
            }
            return RedirectToAction("GetAllRecords");
            //return View();
        }



        public ActionResult __Update(int id)
        {
            var student = repository.GetStudent(id);
            student.Genders = repository.GetGenders();
            
            return PartialView(student);

        }


        [HttpPost]
        public ActionResult __Update(Student student)
        {
            if (ModelState.IsValid)
            {
                repository.updateStudent(student.Id, student);
                return RedirectToAction("GetAllRecords");
            }
            return View(student);
            //return PartialView();   
        }



        public ActionResult GetAllRecords()
        {
            var result = repository.GetAllStudents();
            return View(result);
        }
    }
}