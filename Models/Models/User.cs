using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLibrary.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public int DivisionId { get; set; }
        public int DistrictId { get; set; }
        public string PresentAddress { get; set; }
        public string LastEducation { get; set; }
        public string Occupation { get; set; }
        public DateTime DoB { get; set; }
    }
}
