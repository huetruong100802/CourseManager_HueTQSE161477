﻿using System;
using System.Collections.Generic;
using CourseManager.Repo.Models;

#nullable disable

namespace CourseManager.Service.ViewModels
{
    public partial class SemesterViewModel : BaseEntity
    {
        public SemesterViewModel()
        {
            Courses = new HashSet<CourseViewModel>();
        }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<CourseViewModel> Courses { get; set; }
    }
}
