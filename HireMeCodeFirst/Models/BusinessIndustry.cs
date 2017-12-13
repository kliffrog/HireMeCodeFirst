﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class BusinessIndustry
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Industry")]
        public string Name { get; set; }

    }
}