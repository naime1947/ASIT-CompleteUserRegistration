using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataLibrary.Model;

namespace ASIT_CompleteUserRegistration.Models
{
    public class User
    {
        public int UserId { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }
        public string Gender { get; set; }

        public List<Division> Divisions { get; set; }
        public List<District> Districs { get; set; }

        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        [Display(Name = "Last Education")]
        public string LastEducation { get; set; }
        public string Occupation { get; set; }

        [Required]
        public DateTime DoB { get; set; }
    }
}