﻿using CourseManager.Repo.Commons;
using CourseManager.Repo.Models;
using CourseManager.Repo.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Service.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<bool> Add(T item);
        Task<bool> Delete(T item);
        Task<bool> Update(T item);
        Task<T> GetById(int id);
        Task<T> Get(params Expression<Func<T, object>>[] includes);
        Task<Pagination<T>> GetByPage(int page = 0, int pageSize = 10);
        Task<Pagination<T>> GetByPage(Expression<Func<T, bool>> expression, int pageIndex = 0, int pageSize = 10);
    }
}
