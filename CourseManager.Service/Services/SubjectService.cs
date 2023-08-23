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
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Subject item)
        {
            await _unitOfWork.SubjectRepo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(Subject item)
        {
            _unitOfWork.SubjectRepo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Subject> Get(params Expression<Func<Subject, object>>[] includes)
        {
            return (await _unitOfWork.SubjectRepo.GetAsync(includes))!;
        }

        public async Task<List<Subject>> GetAll()
        {
            return await _unitOfWork.SubjectRepo.GetAllAsync();
        }

        public async Task<Subject> GetById(int id)
        {
            return (await _unitOfWork.SubjectRepo.GetByIdAsync(id))!;
        }

        public async Task<Pagination<Subject>> GetByPage(int page, int pageSize)
        {
            return await _unitOfWork.SubjectRepo.ToPagination(page, pageSize);
        }

        public async Task<bool> Update(Subject item)
        {
            _unitOfWork.SubjectRepo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
