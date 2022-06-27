﻿using System;
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

        public ActionResult Create()
        {
            var model = new Student();
            model.Genders = repository.GetGenders();
            //model.Fname = "Abhishek";
            ViewBag.datas = model.Genders;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model)
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
            return View();
        }




        public ActionResult Index()
        {
            return View();
        }
    }
}