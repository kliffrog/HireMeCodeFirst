using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class JobType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Job Type")]
        public string Name { get; set; }
    }
}