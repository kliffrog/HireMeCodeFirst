using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class UserLog
    {
        [Key]
        public int Id { get; set; }
        public UserAccount UserAccount { get; set; }
        public int UserAccountId { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastApplyDate { get; set; }

    }
}