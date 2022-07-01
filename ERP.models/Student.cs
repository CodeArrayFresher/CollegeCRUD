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
        [Required]
        [StringLength(100)]

        public string Fname { get; set; }
        [StringLength(100)]
        [Required]
        public string MiddleName { get; set; }
        [StringLength(100)]
        [Required]
        public string LastName { get; set; }
   
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime DOB { get; set; }
        //public int MyProperty { get; set; }

        public int genderid { get; set; }
      
        public Gender gender { get; set; }

        //public bool StatusId { get; set; }
        [Required]
        public bool isActive { get; set; }
        //public string Status { get; set; }
        public List<Gender> Genders { get; set; }
        
        //public List<Status> Statuss { get; set; }
        //public gender gender { get; set; }
    }
}
