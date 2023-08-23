using CourseManager.Repo.Commons;
using CourseManager.Repo.Enums;
using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Repo.Repository
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : BaseEntity
    {
        protected readonly CourseManagerDBContext _context;
        protected DbSet<TEntity> _dbSet;

        public GenericRepo(CourseManagerDBContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.Id = _dbSet.OrderBy(x => x.Id).Last().Id+1;
            await _dbSet.AddAsync(entity);
        }

        public async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes
           .Aggregate(_dbSet.AsQueryable(),
               (entity, property) => entity.Include(property))
           .OrderBy(x => x.Id)
           .ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = includes
               .Aggregate(_dbSet.AsQueryable(),
                   (entity, property) => entity.Include(property))
               .AsNoTracking();
            return await query.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }
        public async Task<TEntity?> GetAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = includes
               .Aggregate(_dbSet.AsQueryable(),
                   (entity, property) => entity.Include(property))
               .AsNoTracking();
            return await query.FirstAsync();
        }

        public void SoftRemove(TEntity entity)
        {
            _context.ChangeTracker.Clear();
            entity.Status = BaseStatus.Inactive;
            _dbSet.Update(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public Task<Pagination<TEntity>> ToPagination(int pageIndex = 0, int pageSize = 10)
        {
            return ToPagination(x => true, pageIndex, pageSize);
        }

        public Task<Pagination<TEntity>> ToPagination(Expression<Func<TEntity, bool>> expression, int pageIndex = 0, int pageSize = 10)
        {
            return ToPagination(_dbSet, expression, pageIndex, pageSize);
        }

        public async Task<Pagination<TEntity>> ToPagination(IQueryable<TEntity> value, Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize)
        {
            var itemCount = await value.Where(expression).CountAsync();
            var items = await value.Where(expression)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .OrderBy(x => x.Id)
                                    .AsNoTracking()
                                    .ToListAsync();

            var result = new Pagination<TEntity>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items,
            };

            return result;
        }

    }
}
