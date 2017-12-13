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
        public virtual JobType JobType{ get; set; }
        public int JobTypeId { get; set; }
        public virtual Company Company{ get; set; }
        [Display(Name = "Company Name")]
        public int CompanyId { get; set; }
        public virtual JobLocation JobLocation{ get; set; }
        public int JobLocationId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="Last Modified")]
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public string Qualifications { get; set; }
        [Display(Name = "Application Instructions")]
        public string ApplicationInstructions { get; set; }

        [Display(Name = "Application Website")]
        public string ApplicationWebsite { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Posting Date")]
        public DateTime? PostingDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiration Date")]
        public DateTime? ExpirationDate { get; set; }
        public bool Enabled { get; set; }
        [Display(Name = "Number of Views")]
        public int NumViews { get; set; }

    }
}