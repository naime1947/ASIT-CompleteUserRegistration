using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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
        public string[] Genders = new[] { "Male, Female, Other" };

        [Required]
        [Display(Name = "Division")]
        public int DivisionId { get; set; }
        public IEnumerable<SelectListItem> Divisions { get; set; }

        [Required]
        [Display(Name = "District")]
        public int DistrictId { get; set; }
        public IEnumerable<SelectListItem> Districts { get; set; }

        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        [Display(Name = "Last Education ")]
        public string LastEducation { get; set; }

        public string Occupation { get; set; }

        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DoB { get; set; }
    }
}
