using AutoMapper;
using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using CourseManager.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Room item)
        {
            await _unitOfWork.RoomRepo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(Room item)
        {
            _unitOfWork.RoomRepo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Room> Get(params Expression<Func<Room, object>>[] includes)
        {
            return (await _unitOfWork.RoomRepo.GetAsync(includes))!;
        }

        public async Task<List<Room>> GetAll()
        {
            var rooms =  await _unitOfWork.RoomRepo.GetAllAsync();
            return rooms;
        }

        public async Task<Room> GetById(int id)
        {
            var room = await _unitOfWork.RoomRepo.GetByIdAsync(id);
            return room!;
        }

        public async Task<Pagination<Room>> GetByPage(int page, int pageSize)
        {
            return await _unitOfWork.RoomRepo.ToPagination(page, pageSize);
        }

        public async Task<bool> Update(Room item)
        {
            _unitOfWork.RoomRepo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
