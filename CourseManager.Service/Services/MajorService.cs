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
    public class MajorService : IMajorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MajorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Major item)
        {
            await _unitOfWork.MajorRepo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(Major item)
        {
            _unitOfWork.MajorRepo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Major> Get(params Expression<Func<Major, object>>[] includes)
        {
            return (await _unitOfWork.MajorRepo.GetAsync(includes))!;
        }

        public async Task<List<Major>> GetAll()
        {
            return await _unitOfWork.MajorRepo.GetAllAsync();
        }

        public async Task<Major> GetById(int id)
        {
            return (await _unitOfWork.MajorRepo.GetByIdAsync(id))!;
        }

        public async Task<Pagination<Major>> GetByPage(int page, int pageSize)
        {
            return await _unitOfWork.MajorRepo.ToPagination(page, pageSize);
        }

        public async Task<bool> Update(Major item)
        {
            _unitOfWork.MajorRepo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
