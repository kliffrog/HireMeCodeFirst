using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class EducationDetail
    {
        [Key]
        public int Id { get; set; }
        public UserAccount UserAccount { get; set; }

        public int UserAccountID { get; set; }
        public string CertificateDegree { get; set; }
        public string Major { get; set; }
        public string InstitutionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public int Percentage { get; set; }
        public int GPA { get; set; }

    }
}