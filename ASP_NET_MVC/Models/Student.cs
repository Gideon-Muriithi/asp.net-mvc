using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC.Models
{
    public class Student
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage ="Please enter student name.")]
        public string StudentName { get; set; }
        [Display(Name = "Age")]
        [Range(10,20)]
        public int StudentAge { get; set; }
        //public bool isNewlyEnrolled { get; set; }
        //public string Password { get; set; }
        public int StudentID { get; set; }


    }
}