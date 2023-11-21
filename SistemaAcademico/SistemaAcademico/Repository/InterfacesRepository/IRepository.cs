using System.Linq.Expressions;

namespace SistemaAcademico.Repository.InterfacesRepository
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T GetById(Expression<Func<T, bool>> predicated);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
