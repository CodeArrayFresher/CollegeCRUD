using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.models
{
    public class Student
    {

        public int Id { get; set; }

        [StringLength(100)]
        public string Fname { get; set; }
        [StringLength(100)]
        public string MiddleName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime DOB { get; set; }
        //public int MyProperty { get; set; }

        public int genderid { get; set; }   
        public string Status { get; set; }
        public List<Gender> Genders { get; set; }
        public Gender Gender { get; set; }
    }
}
