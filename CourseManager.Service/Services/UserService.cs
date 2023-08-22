using CourseManager.Repo.Models;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(User item)
        {
            await _unitOfWork.UserRepo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(User item)
        {
            _unitOfWork.UserRepo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<User>> GetAll()
        {
            return await _unitOfWork.UserRepo.GetAllAsync();
        }

        public async Task<User> GetById(int id)
        {
            return (await _unitOfWork.UserRepo.GetByIdAsync(id))!;
        }

        public async Task<bool> Update(User item)
        {
            _unitOfWork.UserRepo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
