using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class JobPostSkillSet
    {
        [Key]
        public int Id { get; set; }
        public JobPosting JobPosting { get; set; }

        public int JobPostingId { get; set; }
        public int SkillLevel { get; set; }

    }
}