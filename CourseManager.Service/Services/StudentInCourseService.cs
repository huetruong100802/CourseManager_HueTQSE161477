using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
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
    public class StudentInCourseService : IStudentInCourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentInCourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(StudentInCourse item)
        {
            await _unitOfWork.StudentInCourseRepo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(StudentInCourse item)
        {
            _unitOfWork.StudentInCourseRepo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<StudentInCourse> Get(params Expression<Func<StudentInCourse, object>>[] includes)
        {
            return (await _unitOfWork.StudentInCourseRepo.GetAsync(includes))!;
        }

        public async Task<List<StudentInCourse>> GetAll()
        {
            return await _unitOfWork.StudentInCourseRepo.GetAllAsync();
        }

        public async Task<StudentInCourse> GetById(int id)
        {
            return (await _unitOfWork.StudentInCourseRepo.GetByIdAsync(id))!;
        }

        public async Task<Pagination<StudentInCourse>> GetByPage(int page, int pageSize)
        {
            return await _unitOfWork.StudentInCourseRepo.ToPagination(page, pageSize);
        }

        public async Task<bool> Update(StudentInCourse item)
        {
            _unitOfWork.StudentInCourseRepo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
