﻿using System;
using System.Collections.Generic;
using CourseManager.Repo.Models;

#nullable disable

namespace CourseManager.Service.ViewModels
{
    public partial class UserViewModel : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        public virtual RoleViewModel Role { get; set; }
    }
}