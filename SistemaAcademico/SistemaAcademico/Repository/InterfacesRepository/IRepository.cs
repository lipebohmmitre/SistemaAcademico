using SistemaAcademico.Models;
using System.Linq.Expressions;

namespace SistemaAcademico.Repository.InterfacesRepository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
