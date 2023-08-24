using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Service.Services
{
    public class StudentInCourseService : Service<StudentInCourse>, IStudentInCourseService
    {
        public StudentInCourseService(IUnitOfWork unitOfWork, IGenericRepo<StudentInCourse> repo) : base(unitOfWork, repo)
        {
        }
    }
}
