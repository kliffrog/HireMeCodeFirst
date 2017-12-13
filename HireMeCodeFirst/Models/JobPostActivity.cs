using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class JobPostActivity
    {
        [Key]
        public int Id { get; set; }
        public UserAccount UserAccount { get; set; }

        public int UserAccountId { get; set; }
        public JobPosting JobPosting { get; set; }
        public int JobPostingId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Apply Date")]
        public DateTime ApplyDate { get; set; }
        public JobApplicationStatus JobApplicationStatus { get; set; }
        public int JobApplicationStatusId { get; set; }
    }
}