﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeCodeFirst.Models
{
    public class JobPostAction
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}