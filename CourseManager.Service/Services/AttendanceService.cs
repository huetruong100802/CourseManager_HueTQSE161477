using CourseManager.Repo.Models;
using CourseManager.Repo.Repository;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;

namespace CourseManager.Service.Services
{
    public class AttendanceService: IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Attendance item)
        {
            await _unitOfWork.AttendanceRepo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<bool> Delete(Attendance item)
        {
            _unitOfWork.AttendanceRepo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<Attendance>> GetAll()
        {
            return await _unitOfWork.AttendanceRepo.GetAllAsync();
        }

        public async Task<Attendance> GetById(int id)
        {
            return (await _unitOfWork.AttendanceRepo.GetByIdAsync(id))!;
        }

        public async Task<bool> Update(Attendance item)
        {
            _unitOfWork.AttendanceRepo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
