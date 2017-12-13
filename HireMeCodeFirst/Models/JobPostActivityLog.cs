using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class JobPostActivityLog
    {
        [Key]
        public int Id { get; set; }
        public JobPostActivity JobPostActivity { get; set; }
        public int JobPostActivityId { get; set; }
        public JobPostAction JobPostAction { get; set; }
        public int JobPostActionId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Action Date")]
        public DateTime ActionDate { get; set; }
        public UserAccount UserAccount { get; set; }
        public int UserAccountId { get; set; }
    }
}