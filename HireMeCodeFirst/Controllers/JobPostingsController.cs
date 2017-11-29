using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HireMeCodeFirst.Models;
using HireMeCodeFirst.ViewModels;
using Microsoft.AspNet.Identity;

namespace HireMeCodeFirst.Controllers
{
    public class JobPostingsController : Controller
    {
        private ApplicationDbContext db;

        public JobPostingsController()
        {
            db = new ApplicationDbContext();
        }

        public ViewResult Index()
        {
            var jobPostings = db.JobPostings.Include(j => j.Company).Include(j => j.JobLocation).Include(j => j.JobType);
            if (User.IsInRole(RoleName.CanManagePostings))
            {
                
                return View(jobPostings.ToList());
            }
            return View("ReadOnlyIndex", jobPostings);
        }

        // GET: JobPostings
        /*public ActionResult Index()
        {
            var jobPostings = db.JobPostings.Include(j => j.Company).Include(j => j.JobLocation).Include(j => j.JobType).Include(j => j.UserAccount);
            return View(jobPostings.ToList());
        }*/

        // GET: JobPostings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Find(id);
            if (jobPosting == null)
            {
                return HttpNotFound();
            }
            return View(jobPosting);
        }

        // GET: JobPostings/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Companies, "Id", "Name");
            ViewBag.JobLocationId = new SelectList(db.JobLocations, "Id", "Address1");
            ViewBag.JobTypeId = new SelectList(db.JobTypes, "Id", "Name");
            ViewBag.UserAccountId = new SelectList(db.UserAccounts, "Id", "Email");
            return View();
        }

        // POST: JobPostings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JobTypeId,CompanyId,JobLocationId,UserAccountId,CreatedDate,JobTitle,JobDescription,NumOpenings,HoursPerWeek,WageSalary,StartDate,EndDate,Qualifications,ApplicationInstructions,ApplicationWebsite,PostingDate,ExpirationDate,Enabled,NumViews")] JobPosting jobPosting)
        {
            if (ModelState.IsValid)
            {
                db.JobPostings.Add(jobPosting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Companies, "Id", "Name", jobPosting.Id);
            ViewBag.JobLocationId = new SelectList(db.JobLocations, "Id", "Address1", jobPosting.JobLocationId);
            ViewBag.JobTypeId = new SelectList(db.JobTypes, "Id", "Name", jobPosting.JobTypeId);
            return View(jobPosting);
        }

        [Authorize(Roles=RoleName.CanManagePostings)]
        public ViewResult New()
        {
            var jobTypes = db.JobTypes.ToList();
            var jobLocations = db.JobLocations.ToList();
            var viewModel = new PostingFormViewModel
            {
                JobTypes = jobTypes,
                JobLocations = jobLocations
            };

            return View("JobPostingForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(JobPosting jobPosting)
        {
            /*if (!ModelState.IsValid)
            {
                var viewModel = new PostingFormViewModel()
                {
                    JobPosting = jobPosting,
                    JobTypes = db.JobTypes,
                    JobLocations = db.JobLocations
                };
                return View("JobPostingForm",viewModel);
            }*/
            if (jobPosting.Id == 0)
                db.JobPostings.Add(jobPosting);
            else
            {
                var JobPostingInDb = db.JobPostings.Single(c => c.Id == jobPosting.Id);
                
                JobPostingInDb.ApplicationInstructions = jobPosting.ApplicationInstructions;
                JobPostingInDb.ApplicationWebsite = jobPosting.ApplicationWebsite;
                JobPostingInDb.CompanyId = 1;
                JobPostingInDb.CreatedDate = DateTime.Now;
                JobPostingInDb.Enabled = false;
                JobPostingInDb.EndDate = jobPosting.EndDate;
                JobPostingInDb.ExpirationDate = jobPosting.ExpirationDate;
                JobPostingInDb.HoursPerWeek = jobPosting.HoursPerWeek;
                JobPostingInDb.JobDescription = jobPosting.JobDescription;
                JobPostingInDb.JobLocationId = 1;
                JobPostingInDb.JobTitle = jobPosting.JobTitle;
                JobPostingInDb.JobTypeId = jobPosting.JobTypeId;
                JobPostingInDb.NumOpenings = jobPosting.NumOpenings;
                JobPostingInDb.NumViews = 0;
                JobPostingInDb.PostingDate = DateTime.Now;
                JobPostingInDb.StartDate = jobPosting.StartDate;
                JobPostingInDb.Qualifications = jobPosting.Qualifications;
                JobPostingInDb.WageSalary = jobPosting.WageSalary;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "JobPostings");
        }

        // GET: JobPostings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Find(id);
            if (jobPosting == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Companies, "Id", "Name", jobPosting.Id);
            ViewBag.JobLocationId = new SelectList(db.JobLocations, "Id", "Address1", jobPosting.JobLocationId);
            ViewBag.JobTypeId = new SelectList(db.JobTypes, "Id", "Name", jobPosting.JobTypeId);
            return View(jobPosting);
        }

        // POST: JobPostings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobTypeId,CompanyId,JobLocationId,UserAccountId,CreatedDate,JobTitle,JobDescription,NumOpenings,HoursPerWeek,WageSalary,StartDate,EndDate,Qualifications,ApplicationInstructions,ApplicationWebsite,PostingDate,ExpirationDate,Enabled,NumViews")] JobPosting jobPosting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPosting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Companies, "Id", "Name", jobPosting.Id);
            ViewBag.JobLocationId = new SelectList(db.JobLocations, "Id", "Address1", jobPosting.JobLocationId);
            ViewBag.JobTypeId = new SelectList(db.JobTypes, "Id", "Name", jobPosting.JobTypeId);
            return View(jobPosting);
        }

        // GET: JobPostings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Find(id);
            if (jobPosting == null)
            {
                return HttpNotFound();
            }
            return View(jobPosting);
        }

        // POST: JobPostings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobPosting jobPosting = db.JobPostings.Find(id);
            db.JobPostings.Remove(jobPosting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
