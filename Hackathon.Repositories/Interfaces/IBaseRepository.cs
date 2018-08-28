using Hackathon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> Get(int id);
        Task Create(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(int id);
    }
}
