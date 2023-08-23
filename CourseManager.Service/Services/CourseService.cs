using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using System.Linq.Expressions;

namespace CourseManager.Service.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Course item)
        {
            await _unitOfWork.CourseRepo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(Course item)
        {
            _unitOfWork.CourseRepo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Course> Get(params Expression<Func<Course, object>>[] includes)
        {
            return (await _unitOfWork.CourseRepo.GetAsync(includes))!;
        }

        public async Task<List<Course>> GetAll()
        {
            return await _unitOfWork.CourseRepo.GetAllAsync();
        }

        public async Task<Course> GetById(int id)
        {
            return (await _unitOfWork.CourseRepo.GetByIdAsync(id))!;
        }

        public async Task<Pagination<Course>> GetByPage(int page, int pageSize)
        {
            return await _unitOfWork.CourseRepo.ToPagination(page, pageSize);
        }

        public async Task<bool> Update(Course item)
        {
            _unitOfWork.CourseRepo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
