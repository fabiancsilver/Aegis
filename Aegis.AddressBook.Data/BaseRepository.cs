using Aegis.AddressBook.Application.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aegis.AddressBook.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>()
                                   .FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>()
                                   .ToListAsync();
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponse(int page, int size)
        {
            return await _dbContext.Set<T>().Skip((page - 1) * size)
                                   .Take(size)
                                   .AsNoTracking()
                                   .ToListAsync();
        }

        public void Create(T entity)
        {
            _dbContext.Set<T>()
                      .Add(entity);
        }

        public void Update(int id, T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Remove(int id)
        {
            var item = await _dbContext.Set<T>()
                                       .FindAsync(id);
            if (item == null)
            {
                throw new ArgumentException();
            }
            _dbContext.Remove(item);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}