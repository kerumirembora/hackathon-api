using Hackathon.Model;
using Hackathon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Repositories.SQLLite
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly SQLLiteContext _dbContext;

        protected SQLLiteContext Context { get { return _dbContext; } }

        public BaseRepository(SQLLiteContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Get(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
