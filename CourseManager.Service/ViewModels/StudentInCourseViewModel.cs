using System;
using System.Collections.Generic;
using CourseManager.Repo.Models;

#nullable disable

namespace CourseManager.Service.ViewModels
{
    public partial class StudentInCourseViewModel : BaseEntity
    {
        public StudentInCourseViewModel()
        {
            Attendances = new HashSet<AttendanceViewModel>();
        }

        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual CourseViewModel Course { get; set; }
        public virtual StudentViewModel Student { get; set; }
        public virtual ICollection<AttendanceViewModel> Attendances { get; set; }
    }
}
