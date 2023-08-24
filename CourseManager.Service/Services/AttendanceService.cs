﻿using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Repo.Repository;
using CourseManager.Repo.Repository.Interface;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using System.Linq.Expressions;

namespace CourseManager.Service.Services
{
    public class AttendanceService : Service<Attendance>, IAttendanceService
    {
        public AttendanceService(IUnitOfWork unitOfWork, IGenericRepo<Attendance> repo) : base(unitOfWork, repo)
        {
        }
    }
}
