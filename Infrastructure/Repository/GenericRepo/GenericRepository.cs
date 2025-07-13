using Application.Interfaces.Generic;
using Domain.entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.GenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class,IEntity
    {

       private readonly  DbContext  _dbContext ;
       private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();

        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();


        public async Task<int> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);

                bool deferSave = entity is Review || entity is ItemGallery;
                if (deferSave)
                {
                    await _dbContext.SaveChangesAsync();
                }

                return entity.Id;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);

            }

        }

        public async Task <bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return false;
        }
        public  async  Task<T>  GetByIDAsync(int id)
        {
            try
            {
                 return await  _dbSet .FindAsync(id);
            }
            catch ( Exception ex) { throw new Exception(ex.Message); }
        }

        public  async Task<bool> UpdateAsync( T entity)
        {
            try
            {

                _dbSet.Update(entity);
               return await _dbContext.SaveChangesAsync()!=0;
               
            }
            catch (Exception ex){ throw new Exception(ex.Message); }
        }
    }
}
