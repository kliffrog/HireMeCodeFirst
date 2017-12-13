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


using System.Linq.Dynamic;
using PagedList;


namespace HireMeCodeFirst.Controllers
{
    public class JobPostingsController : Controller
    {
        private ApplicationDbContext db;
        public JobPostingsController()
        {
            db = new ApplicationDbContext();
        }

        

        public ActionResult Index()
        {
           /* var jobPostings = db.JobPostings.Include(j => j.Company).Include(j => j.JobLocation).Include(j => j.JobType).Include(j => j.Company.BusinessIndustry).ToList().OrderBy(c => c.Enabled);
            
            if (User.IsInRole(RoleName.CanManagePostings))
            {
                return View(jobPostings);
            }
            return View("ReadOnlyIndex", jobPostings);*/
            return View(db.JobPostings.ToList().OrderBy(c => c.Enabled));
        }

        // GET: JobPostings
        /*public ActionResult Index()
        {
            var jobPostings = db.JobPostings.Include(j => j.Company).Include(j => j.JobLocation).Include(j => j.JobType).Include(j => j.Company.BusinessIndustry);
            return View(jobPostings.ToList());
        }*/

        // GET: JobPostings/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Include(j => j.Company).Include(j => j.JobLocation).Include(j => j.JobType).Single(j => j.Id == id);
            
            if (jobPosting == null)
            {
                return HttpNotFound();
            }

            return View(jobPosting);
        }

       

        // GET: JobPostings/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name");
            ViewBag.JobLocationId = new SelectList(db.JobLocations, "Id", "Address1");
            ViewBag.JobTypeId = new SelectList(db.JobTypes, "Id", "Name");

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
                int ID = (db.JobPostings.Count() + 1);
                jobPosting.Id = ID;
                jobPosting.CreatedDate = DateTime.Now;
                db.JobPostings.Add(jobPosting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", jobPosting.CompanyId);
            ViewBag.JobLocationId = new SelectList(db.JobLocations, "Id", "Address1", jobPosting.JobLocationId);
            ViewBag.JobTypeId = new SelectList(db.JobTypes, "Id", "Name", jobPosting.JobTypeId);
            
            return View(jobPosting);
        }

        [Authorize(Roles=RoleName.CanManagePostings)]
        public ViewResult New()
        {
            var jobTypes = db.JobTypes.ToList();
            var jobLocations = db.JobLocations.ToList();
            var companies = db.Companies.ToList();
            var viewModel = new PostingFormViewModel
            {
                JobTypes = jobTypes,
                JobLocations = jobLocations,
                Company = companies
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
            {
                //System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Hello this is an Alert')</SCRIPT>");
                db.JobPostings.Add(jobPosting);
            }
            else
            {
                var JobPostingInDb = db.JobPostings.Single(c => c.Id == jobPosting.Id);
                
                JobPostingInDb.ApplicationInstructions = jobPosting.ApplicationInstructions;
                JobPostingInDb.ApplicationWebsite = jobPosting.ApplicationWebsite;
                JobPostingInDb.CompanyId = jobPosting.CompanyId;
                JobPostingInDb.CreatedDate = DateTime.Now;
                JobPostingInDb.Enabled = jobPosting.Enabled;
                JobPostingInDb.EndDate = jobPosting.EndDate;
                JobPostingInDb.ExpirationDate = jobPosting.ExpirationDate;
                JobPostingInDb.HoursPerWeek = jobPosting.HoursPerWeek;
                JobPostingInDb.JobDescription = jobPosting.JobDescription;
                JobPostingInDb.JobLocationId = jobPosting.JobLocationId;
                JobPostingInDb.JobTitle = jobPosting.JobTitle;
                JobPostingInDb.JobTypeId = jobPosting.JobTypeId;
                JobPostingInDb.NumOpenings = jobPosting.NumOpenings;
                JobPostingInDb.NumViews = jobPosting.NumViews;
                JobPostingInDb.PostingDate = jobPosting.PostingDate;
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

        // GET: JobPosting
        public ViewResult JobSearch(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.SortTitle = String.IsNullOrEmpty(sortOrder) ? "titleDesc" : "";
            ViewBag.SortDate = sortOrder == "Date" ? "dateDesc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //var postings = from s in db.JobPostings select s;
            var postings = db.JobPostings.ToList().Where(c => c.Enabled == true);

            if (!String.IsNullOrEmpty(searchString))
            {
                postings = postings.Where(s => s.JobTitle.Contains(searchString) || s.JobDescription.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "titleDesc":
                    postings = postings.OrderByDescending(s => s.JobTitle);
                    break;
                case "Date":
                    postings = postings.OrderBy(s => s.PostingDate);
                    break;
                case "dateDesc":
                    postings = postings.OrderByDescending(s => s.CreatedDate);
                    break;
                default:
                    postings = postings.OrderBy(s => s.PostingDate);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(postings.ToPagedList(pageNumber, pageSize));
        }

       /*   public ActionResult JobSearch()
           {
                //Bind Industry drop down in search
                ViewBag.Companies = new SelectList(db.Companies, "Name", "Name");
                ViewBag.IndustriesIndustryName = new SelectList(db.BusinessIndustries, "Name", "Name");
                ViewBag.JobType = new SelectList(db.JobTypes, "Name", "Name");
           var model = new SearchViewModel();
                var results = db.JobPostings.Include(j => j.Company).Include(j => j.JobLocation).Include(j => j.JobType).Include(j => j.Company.BusinessIndustry)
                    .Where(
                p =>
                (model.JobTitle == null || p.JobTitle.StartsWith(model.JobTitle))
                && (model.Company.BusinessIndustry.Name == null || p.Company.BusinessIndustry.Name == model.Company.BusinessIndustry.Name)
                && (model.Company.Name == null || p.Company.Name.Equals(model.Company.Name))
                && (model.JobType.Name == null || p.JobType.Name.StartsWith(model.JobType.Name)))
                        .OrderBy(p => p.CreatedDate);

            return View(model);
          
           }*/

       

     
        public ActionResult SearchDetails(int? id)
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



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult EmployerIndex()
        {
            return View(db.JobPostings.ToList().OrderBy(c => c.CompanyId));
        }
    }
}
