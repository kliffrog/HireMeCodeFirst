using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public UserAccount UserAccount { get; set; }
        public string UserAccountId { get; set; }

        [Display(Name="Company Name")]
        public string Name { get; set; }

        public string Description { get; set; }
        public virtual BusinessIndustry BusinessIndustry{ get; set; }
        public int BusinessIndustryId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="Date Established")]
        public DateTime EstablishmentDate { get; set; }
        public string Website { get; set; }
    }
}