using SistemaAcademico.Models;

namespace SistemaAcademico.Repository.InterfacesRepository
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<IEnumerable<Curso>> GetCursosSubCategoriasAndCategorias();
    }
}
