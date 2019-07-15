using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Models.ViewModels
{
    public class UserEditViewModel
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Gender { get; set; }
        public string[] Genders = new[] {"Male, Female, Other"};
        

        public int DivisionId { get; set; }
        public int DistrictId { get; set; }
        public string PresentAddress { get; set; }
        public string LastEducation { get; set; }
        public string Occupation { get; set; }
        public DateTime DoB { get; set; }
    }
}
