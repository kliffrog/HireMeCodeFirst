using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HireMeCodeFirst.Models;

namespace HireMeCodeFirst.ViewModels
{
    public class JobSearchViewModel
    {
        public IEnumerable<JobType> JobTypes { get; set; }
        public IEnumerable<JobPosting> JobPostings { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<BusinessIndustry> BusinessIndustries { get; set; }
    }
}