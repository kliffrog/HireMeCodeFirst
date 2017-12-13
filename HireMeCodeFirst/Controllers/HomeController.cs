using HireMeCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace HireMeCodeFirst.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManagePostings))
                return View("AdminIndex");
            if (User.IsInRole(RoleName.IsCompany))
                return View("EmployerIndex");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Career Development Center";

            return View();
        }
    }
}