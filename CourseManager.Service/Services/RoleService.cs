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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Role item)
        {
            await _unitOfWork.RoleRepo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(Role item)
        {
            _unitOfWork.RoleRepo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Role> Get(params Expression<Func<Role, object>>[] includes)
        {
            return (await _unitOfWork.RoleRepo.GetAsync(includes))!;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _unitOfWork.RoleRepo.GetAllAsync();
        }

        public async Task<Role> GetById(int id)
        {
            return (await _unitOfWork.RoleRepo.GetByIdAsync(id))!;
        }

        public async Task<Pagination<Role>> GetByPage(int page, int pageSize)
        {
            return await _unitOfWork.RoleRepo.ToPagination(page, pageSize);
        }

        public async Task<bool> Update(Role item)
        {
            _unitOfWork.RoleRepo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
