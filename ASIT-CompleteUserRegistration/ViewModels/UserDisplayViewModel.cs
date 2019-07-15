using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASIT_CompleteUserRegistration.ViewModels
{
    public class UserDisplayViewModel
    {
        public int UserId { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Gender { get; set; }

        public string Division { get; set; }
        public string District { get; set; }

        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        [Display(Name = "Last Education ")]
        public string LastEducation { get; set; }

        public string Occupation { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DoB { get; set; }
    }
}