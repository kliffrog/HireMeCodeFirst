using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HireMeCodeFirst.Models;
using HireMeCodeFirst.ViewModels;

namespace HireMeCodeFirst.Controllers
{
    [Authorize]
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        private ApplicationDbContext _context;

        public UserAccountController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var userAccounts = _context.UserAccounts.ToList();
            return View(userAccounts);
        }
        public ActionResult New()
        {
            var userTypes = _context.UserTypes.ToList();
            var viewModel = new UserAccountFormViewModel
            {
                UserTypes = userTypes
            };
            return View("UserAccountForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(UserAccount userAccount)
        {
            if (userAccount.Id == 0)
                _context.UserAccounts.Add(userAccount);
            else
            {
                var UserAccountInDb = _context.UserAccounts.Single(c => c.Id == userAccount.Id);

                UserAccountInDb.UserTypeId = userAccount.UserTypeId;
                UserAccountInDb.Email = userAccount.Email;
                UserAccountInDb.Password = userAccount.Password;
                UserAccountInDb.Enabled = false;
                UserAccountInDb.RegistrationDate = DateTime.Now;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "UserAccount");
        }

        public ActionResult Details(int Id)
        {
            var useraccount = _context.UserAccounts.SingleOrDefault(c => c.Id == Id);
            if (useraccount == null)
            {
                return HttpNotFound();
            }
            return View(useraccount);
        }

        public ActionResult Edit(int Id)
        {
            var userAccount = _context.UserAccounts.SingleOrDefault(c => c.Id == Id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }

            var viewModel = new UserAccountFormViewModel
            {
                UserAccount = userAccount,
                UserTypes = _context.UserTypes.ToList()
            };
            
            return View("UserAccountForm", viewModel);
        }
    }
}