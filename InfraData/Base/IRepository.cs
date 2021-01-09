using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocadoraAspNet.Models.Base;

namespace LocadoraAspNet.InfraData.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<(Exception, TEntity)> AddAsync(TEntity entity);
        Task<(Exception, IEnumerable<TEntity>)> GetAllAsync();
        Task<(Exception, TEntity)> GetByIdAsync(int id);
        Task<(Exception, TEntity)> UpdateAsync(TEntity entity);
        Task<(Exception, TEntity)> DeleteAsync(int id);
    }
}