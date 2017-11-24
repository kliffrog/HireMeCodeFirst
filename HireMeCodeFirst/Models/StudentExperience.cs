using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class StudentExperience
    {
        [Key]
        public int Id { get; set; }
        public UserAccount UserAccount { get; set; }
        public int UserAccountId { get; set; }
        public bool CurrentJob { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string JobCity { get; set; }
        public string JobState { get; set; }
        public string JobCountry { get; set; }
        public string Description { get; set; }

    }
}