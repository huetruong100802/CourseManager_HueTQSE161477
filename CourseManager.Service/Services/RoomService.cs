using AutoMapper;
using CourseManager.Repo.Models;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using CourseManager.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Add(RoomViewModel item)
        {
            await _unitOfWork.RoomRepo.AddAsync(_mapper.Map<Room>(item));
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(RoomViewModel item)
        {
            _unitOfWork.RoomRepo.SoftRemove(_mapper.Map<Room>(item));
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<RoomViewModel>> GetAll()
        {
            var rooms =  await _unitOfWork.RoomRepo.GetAllAsync();
            return _mapper.Map<List<RoomViewModel>>(rooms);
        }

        public async Task<RoomViewModel> GetById(int id)
        {
            var room = await _unitOfWork.RoomRepo.GetByIdAsync(id);
            return _mapper.Map<RoomViewModel>(room);
        }

        public async Task<bool> Update(RoomViewModel item)
        {
            _unitOfWork.RoomRepo.Update(_mapper.Map<Room>(item));
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
