﻿using System;
using System.Collections.Generic;
using CourseManager.Repo.Models;

#nullable disable

namespace CourseManager.Service.ViewModels
{
    public partial class SessionViewModel : BaseEntity
    {
        public SessionViewModel()
        {
            Attendances = new HashSet<AttendanceViewModel>();
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }

        public virtual CourseViewModel Course { get; set; }
        public virtual RoomViewModel Room { get; set; }
        public virtual ICollection<AttendanceViewModel> Attendances { get; set; }
    }
}
