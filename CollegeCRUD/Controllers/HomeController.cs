﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.DB.DBoperation;
using ERP.models;

namespace CollegeCRUD.Controllers
{
    //[RoutePrefix("Home")]
    //[Route("action = getallrecords")]
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
            return PartialView("__Create",model);
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
            
            return PartialView("__Update",student);

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

        public ActionResult MultipleDelete(int[] multidelete)
        {
            try
            {
            repository.MultipleDelete(multidelete);

            return RedirectToAction("GetAllRecords");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Delete(int id)
        {
            repository.DeleteStudent(id);
            return RedirectToAction("GetAllRecords");
        }

        //[Route("GetAllRecords")]

       


        public ActionResult GetAllRecords()
        {
            var result = repository.GetAllStudents();
            return View(result);
        }
    }
}