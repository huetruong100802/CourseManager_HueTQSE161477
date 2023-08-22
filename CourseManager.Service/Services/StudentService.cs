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
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Student item)
        {
            await _unitOfWork.StudentRepo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(Student item)
        {
            _unitOfWork.StudentRepo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _unitOfWork.StudentRepo.GetAllAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return (await _unitOfWork.StudentRepo.GetByIdAsync(id))!;
        }

        public async Task<bool> Update(Student item)
        {
            _unitOfWork.StudentRepo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
