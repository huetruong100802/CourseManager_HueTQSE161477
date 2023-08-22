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
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Session item)
        {
            await _unitOfWork.SessionRepo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(Session item)
        {
            _unitOfWork.SessionRepo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<Session>> GetAll()
        {
            return await _unitOfWork.SessionRepo.GetAllAsync();
        }

        public async Task<Session> GetById(int id)
        {
            return (await _unitOfWork.SessionRepo.GetByIdAsync(id))!;
        }

        public async Task<bool> Update(Session item)
        {
            _unitOfWork.SessionRepo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
