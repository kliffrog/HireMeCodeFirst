using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class StudentSkillSet
    {
        [Key]
        public int Id { get; set; }
        public UserAccount UserAccount { get; set; }

        public int UserAccountId { get; set; }
        public SkillSet SkillSet { get; set; }
        public int SkillSetId { get; set; }
        public int SkillLevel { get; set; }

    }
}