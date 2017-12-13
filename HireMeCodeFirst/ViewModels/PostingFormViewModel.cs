using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HireMeCodeFirst.Models;

namespace HireMeCodeFirst.ViewModels
{
    public class PostingFormViewModel
    {
        internal List<Company> Companies;

        public IEnumerable<JobType> JobTypes { get; set; }
        public IEnumerable<JobLocation> JobLocations { get; set; }
        public JobPosting JobPosting { get; set; }
        public IEnumerable<Company> Company { get; set; }
    }
}