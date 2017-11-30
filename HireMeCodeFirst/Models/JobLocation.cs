using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class JobLocation
    {
        [Key]
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        [Display(Name = "Address")]
        public string Address1 { get; set; }
        [Display(Name = "")]
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

    }
}