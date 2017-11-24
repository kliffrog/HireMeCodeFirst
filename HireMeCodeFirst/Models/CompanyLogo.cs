using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class CompanyLogo
    {
        [Key]
        public int Id { get; set; }
        public Company Company { get; set; }

        public int CompanyId { get; set; }
        public string Image { get; set; }
    }
}