using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class JobPosting
    {
        [Key]
        public int Id { get; set; }
        public JobType JobType { get; set; }
        public int JobTypeId { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public JobLocation JobLocation { get; set; }
        public int JobLocationId { get; set; }

        public DateTime? CreatedDate { get; set; }
        [Required]
        [Display(Name="Job Title")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name ="Job Description")]
        public string JobDescription { get; set; }
        [Display(Name ="Number of Openings")]
        public int NumOpenings { get; set; }
        [Display(Name ="Hours Per Week")]
        public int HoursPerWeek { get; set; }
        [Display(Name = "Wage/Salary")]
        public decimal WageSalary { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public string Qualifications { get; set; }
        [Display(Name = "Application Instructions")]
        public string ApplicationInstructions { get; set; }
        [Display(Name = "Application Website")]
        public string ApplicationWebsite { get; set; }
        [Display(Name = "Posting Date")]
        [DataType(DataType.Date)]
        public DateTime? PostingDate { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }
        public bool Enabled { get; set; }
        [Display(Name = "Number of Views")]
        public int NumViews { get; set; }

    }
}