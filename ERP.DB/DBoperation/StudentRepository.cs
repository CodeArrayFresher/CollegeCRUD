using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.models;
//using ERP.DB;

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
                         isActive = model.isActive,
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

 

        public List<Student> GetAllStudents()
        {
            using (var context = new StudentDBEntities1())

            {
                var res = context.StudentDetails.Where(x=>x.isDeleted == false).Select(x => new Student()
                {
                    Id = x.Id,
                    Fname = x.Fname,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    DOB = (DateTime)x.DOB,
                    gender = new models.Gender()
                    {
                        Name = x.Gender.Name,
                    },
                 isActive = x.isActive

                }
                ).DefaultIfEmpty().ToList();
                return res;
            }
        }

        public Student GetStudent(int id)
        {
            using (var context = new StudentDBEntities1())

            {
                var result = context.StudentDetails.Where(x => x.Id == id).Select(x => new Student()
                {
                    Id = x.Id,
                    Fname = x.Fname,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    DOB = (DateTime)x.DOB,
                    genderid = x.GenderId,
                    isActive = x.isActive
                }).FirstOrDefault();
                return result;
            }
        }

  


        public bool updateStudent(int id, Student student)
        {
            using (var context = new StudentDBEntities1())
            {
                var stud = context.StudentDetails.FirstOrDefault(x => x.Id == id);
                    if (stud != null)
                {
                    stud.Fname = student.Fname;
                    stud.LastName = student.LastName;
                  stud.MiddleName = student.MiddleName;
                    stud.DOB = student.DOB;
                    stud.GenderId = student.genderid;
                    stud.isActive = student.isActive;

                }
                context.SaveChanges();

            return true;
               
            }

        }

        public bool DeleteStudent(int id)
        {
            using (var context = new StudentDBEntities1())
            {
                var del = context.StudentDetails.Where(x => x.isDeleted == false && x.Id == id).FirstOrDefault();
                del.isDeleted = true;
                context.SaveChanges();
                return true;

            }
        }
    }
}
