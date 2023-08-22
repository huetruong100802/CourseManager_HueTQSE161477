using System;
using System.Collections.Generic;
using CourseManager.Repo.Models;

#nullable disable

namespace CourseManager.Service.ViewModels
{
    public partial class AttendanceViewModel : BaseEntity
    {
        public int StudentInCourseId { get; set; }
        public int SessionId { get; set; }
        public string Description { get; set; }
        public DateTime? AttendanceDate { get; set; }

        public virtual SessionViewModel Session { get; set; }
        public virtual StudentInCourseViewModel StudentInCourse { get; set; }
    }
}
