using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Models.Context;
using SistemaAcademico.Repository.InterfacesRepository;
using System.Linq.Expressions;

namespace SistemaAcademico.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected SistemaAcademicoDbContext _context;

        public Repository(SistemaAcademicoDbContext context)
        {
            _context = context;
        }




        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDeleted = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entityToDeleted);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
