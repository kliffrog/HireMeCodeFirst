using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        public UserType UserType { get; set; }
        [Display(Name="User Type")]
        public int UserTypeId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string VerifyPassword { get; set; }
        public bool Enabled { get; set; }
        [Display(Name="Registration Date")]
        public DateTime RegistrationDate { get; set; }

    }
}