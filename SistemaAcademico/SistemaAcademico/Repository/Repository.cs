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




        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(Expression<Func<T, bool>> predicated)
        {
            return _context.Set<T>().FirstOrDefault(predicated);
        }

        
    }
}
