using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraAspNet.Exceptions;
using LocadoraAspNet.InfraData.Contexts;
using LocadoraAspNet.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAspNet.InfraData.Base
{
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DataContext _context;

        public AbstractRepository(DataContext context)
        {
            _context = context;
        }

        protected virtual IQueryable<TEntity> FindByIdCustomQuery() => _context.Set<TEntity>().AsQueryable();
        protected virtual IQueryable<TEntity> FindAllCustomQuery() => _context.Set<TEntity>().AsQueryable();

        public async Task<(Exception, TEntity)> AddAsync(TEntity entity)
        {
            TEntity newEntity;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                newEntity = _context.Set<TEntity>().Add(entity).Entity;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (ex, null);
            }

            return (null, newEntity);
        }

        public async Task<(Exception, TEntity)> DeleteAsync(int id)
        {
            TEntity deletedEntity;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                deletedEntity = await _context.Set<TEntity>().FindAsync(id);
                if (deletedEntity == null)
                {
                    await transaction.RollbackAsync();
                    return (new NotFoundException(), null);
                }
                _context.Set<TEntity>().Remove(deletedEntity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (ex, null);
            }

            return (null, deletedEntity);
        }

        public async Task<(Exception, IEnumerable<TEntity>)> GetAllAsync()
        {
            try
            {
                var entities = await FindAllCustomQuery().ToListAsync();
                return (null, entities);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public async Task<(Exception, TEntity)> GetByIdAsync(int id)
        {
            try
            {
                var entity = await FindByIdCustomQuery().FirstOrDefaultAsync(e => e.Id == id);
                if (entity == null)
                    return (new NotFoundException(), null);
                return (null, entity);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public async Task<(Exception, TEntity)> UpdateAsync(TEntity entity)
        {
            TEntity updatedEntity;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                updatedEntity = _context.Set<TEntity>().Update(entity).Entity;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (ex, null);
            }

            return (null, updatedEntity);
        }
    }
}