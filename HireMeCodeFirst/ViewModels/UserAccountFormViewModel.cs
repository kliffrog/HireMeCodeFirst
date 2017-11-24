using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HireMeCodeFirst.Models;

namespace HireMeCodeFirst.ViewModels
{
    public class UserAccountFormViewModel
    {
        public IEnumerable<UserType> UserTypes { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}