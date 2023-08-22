﻿using System;
using System.Collections.Generic;
using CourseManager.Repo.Models;

#nullable disable

namespace CourseManager.Service.ViewModels
{
    public partial class RoleViewModel : BaseEntity
    {
        public RoleViewModel()
        {
            Users = new HashSet<UserViewModel>();
        }

        public string Name { get; set; }

        public virtual ICollection<UserViewModel> Users { get; set; }
    }
}
