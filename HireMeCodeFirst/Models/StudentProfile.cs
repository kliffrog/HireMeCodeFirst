using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }
        public UserAccount UserAccount { get; set; }
        public int UserAccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string CellPhone { get; set; }
        public string CellProvider { get; set; }
        public string Website { get; set; }
        public bool EmployerViewing { get; set; }
    }
}