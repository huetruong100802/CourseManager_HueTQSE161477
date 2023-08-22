﻿using CourseManager.Repo.Models;
using CourseManager.Repo.UnitOfWorks;
using CourseManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Service.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SemesterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Semester item)
        {
            await _unitOfWork.SemesterRepo.AddAsync(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(Semester item)
        {
            _unitOfWork.SemesterRepo.SoftRemove(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<Semester>> GetAll()
        {
            return await _unitOfWork.SemesterRepo.GetAllAsync();
        }

        public async Task<Semester> GetById(int id)
        {
            return (await _unitOfWork.SemesterRepo.GetByIdAsync(id))!;
        }

        public async Task<bool> Update(Semester item)
        {
            _unitOfWork.SemesterRepo.Update(item);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}