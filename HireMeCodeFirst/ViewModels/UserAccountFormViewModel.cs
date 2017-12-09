using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HireMeCodeFirst.Models;

namespace HireMeCodeFirst.ViewModels
{
    public class UserAccountFormViewModel
    {
        public IEnumerable<ApplicationUser> UserTypes { get; set; }
        public ApplicationUser UserAccount { get; set; }
    }
}