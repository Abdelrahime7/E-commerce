using Application.Interfaces.Generic;
using Domain.entities;
using Domain.Interface;
using Infrastructure.ADbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.GenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class,IEntity
    {

       private readonly AppDbContext _dbContext ;
       private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();

        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();


        public async Task<int> AddAsync(T entity)
        {
            
                await _dbSet.AddAsync(entity);

                bool deferSave = entity is Review || entity is ItemGallery;
                if (deferSave)
                {
                    await _dbContext.SaveChangesAsync();
                }

                return entity.Id;
           

            

        }

        public async Task<int> SoftDeleteAsync(int id) 
        {
           
                var entity = await _dbSet.FindAsync(id);
                if (entity is null) return 0;
                entity.IsDeleted = true;
                _dbSet.Update(entity);

                return await _dbContext.SaveChangesAsync();
           
                
         
        }
       
        public async Task <bool> DeleteAsync(int id)
        {
              var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public  async  Task<T>  GetByIDAsync(int id)
        {

            return await _dbSet.FindAsync(id);
              
                    

          
        }

        public  async Task<bool> UpdateAsync( T entity)
        {
           

                _dbSet.Update(entity);
               return await _dbContext.SaveChangesAsync()!=0;
           
        }
    }
}
