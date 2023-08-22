using System;
using System.Collections.Generic;
using CourseManager.Repo.Models;

#nullable disable

namespace CourseManager.Service.ViewModels
{
    public partial class StudentViewModel : BaseEntity
    {
        public StudentViewModel()
        {
            StudentInCourses = new HashSet<StudentInCourseViewModel>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime EnrollDate { get; set; }
        public int MajorId { get; set; }

        public virtual MajorViewModel Major { get; set; }
        public virtual ICollection<StudentInCourseViewModel> StudentInCourses { get; set; }
    }
}
