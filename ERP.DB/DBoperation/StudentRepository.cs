﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.models;
using ERP.DB;

namespace ERP.DB.DBoperation
{
    public class StudentRepository
    {
        public int AddStudent(Student model)
        {

            try
            {
                using (var context = new StudentDBEntities1())
                {

                    

                    //var student = context.StudentDetails.Where(x => x.Id == 1).Select(x => new models.Student
                    //{
                    //    Id= x.Id,
                    //    Fname = x.Fname,
                    //    Gender = new models.Gender { 
                    //           Name = x.Gender.Name 
                    //    }
                    //}).FirstOrDefault();



                    StudentDetail stud = new StudentDetail()
                    {
                        Fname = model.Fname,
                        MiddleName = model.MiddleName,
                        LastName = model.LastName,
                        DOB = model.DOB,
                        GenderId = model.genderid,
                        StatusId = 1,
                        //Gender = model.Gender,  
                        ////Status = model.Status,  
                    };
                    //context.StudentDetails.Add(stud);
                    context.StudentDetails.Add(stud);
                    context.GetValidationErrors();
                    context.SaveChanges();
                    return stud.Id;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<models.Gender> GetGenders()
        {

            try
            {
                using (var context = new StudentDBEntities1())
                {

                    var abc = context.Genders.Select(x => new models.Gender
                    {
                        id = x.id,
                        Name = x.Name
                    }).ToList();

                    return abc;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}